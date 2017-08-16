using SING.Data.DAL.NewCode;
using SING.Data.DAL.NewCode.Condition;
using SING.Data.DAL.NewCode.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACE_TemplateManagement.Services.HelpService
{
    public class SysTypecodeService
    {
        public List<SysTypecodeData> Query()
        {
            Pager<SysTypecodeDataCondition> pager = new Pager<SysTypecodeDataCondition>
            {
                PageNo = 1,
                PageRows = 20,
                Condition = new SysTypecodeDataCondition {
                    TypeCode="1"
                }
                //Condition = new System.Collections.Hashtable()
            };
            //pager.Condition.Add("typeCode", "");
            SysTypecode code = new SysTypecode();
            Pager<SysTypecodeDataCondition, SysTypecode> p = code.Query(pager);
            List<SysTypecodeData> result = new List<SysTypecodeData>();
            List<SysTypecode> codes = p.ResultList;
            codes.ForEach(c=> { result.Add(c.ToUIData<SysTypecodeData>()); });
            return result;
        }
    }
}
