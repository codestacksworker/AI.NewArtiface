using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.BaseTools
{
    public class MQSubMessageParameters
    {
        #region Properties

        private const string FACE = "face";

        private string Filter;
        public string Header { get; set; }
        public string Region { get; set; }
        public string Channel { get; set; }
        public string FtdbId { get; set; }
        public string Name { get; set; }

        #endregion
        public MQSubMessageParameters(string header, string name)
        {
            this.Header = header;
            this.Name = name;
            Filter = "topic1";
        }

        public MQSubMessageParameters(string header, string region, string channel)
        {
            this.Header = header;
            this.Region = region;
            this.Channel = channel;
            Filter = "topic2";
        }

        public MQSubMessageParameters(string header, string region, string channel, string ftdbId)
        {
            this.Header = header;
            this.Region = region;
            this.Channel = channel;
            this.FtdbId = ftdbId;
            Filter = "topic3";
        }

        public override string ToString()
        {
            string topic = string.Empty;

            switch (Filter)
            {

                case "topic1":
                    topic = $"{FACE}.{Header}.*.{Name}";
                    break;

                case "topic2":
                    topic = string.IsNullOrEmpty(Channel) ? $"{FACE}.{Header}.*.{Region}.>" : $"{FACE}.{Header}.{Channel}.>";
                    break;

                case "topic3":
                    topic = $"{FACE}.{Header}";

                    if (!string.IsNullOrEmpty(Channel))
                    {
                        topic += $".{Channel}";
                    }
                    else
                    {
                        topic += $".*";
                    }

                    if (!string.IsNullOrEmpty(FtdbId))
                    {
                        topic += $".{FtdbId}";
                    }
                    else
                    {
                        topic += $".*";
                    }

                    if (!string.IsNullOrEmpty(Region))
                    {
                        if (Region.First() == '.')
                            topic += $"{Region}";
                        else
                            topic += $".{Region}";
                    }
                    else
                    {
                        topic += $".*";
                    }

                    topic += $".>";
                    break;
            }

            //if (string.IsNullOrEmpty(Name))
            //{


            //    //topic = "face.cap.387517b4a7ab4c50a55b083899516bee.>";
            //    //topic = string.IsNullOrEmpty(Channel) ? $"{FACE}.{Header}.*.{Region}" : $"{FACE}.{Header}.{Channel}.{Region}";
            //}
            //else
            //{
            //    topic = $"{FACE}.{Header}.*.{Name}";
            //}

            //topic = string.IsNullOrEmpty(Channel) ? $"{FACE}.{Header}.*.01" : $"{FACE}.{Header}.ch1.01";

            return topic;
        }
    }
}
