#region Usings

using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;

using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;
using DotNetNuke.Entities.Host;
using DotNetNuke.Instrumentation;
using DotNetNuke.Security;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

#endregion

namespace Satrabel.Services.Log.UrlRule
{



    public class UrlRuleController
    {
        private const string ModuleQualifier = "OpenUrlRewriter_";

        public static int AddUrlRule(UrlRuleInfo objUrlRule)
        {
            try
            {
                var result = DotNetNuke.Data.DataProvider.Instance().ExecuteScalar(ModuleQualifier + "AddUrlRule",
                                                          objUrlRule.DateTime,
                                                          objUrlRule.UserId,
                                                          objUrlRule.RuleType,
                                                          GetNull(objUrlRule.CultureCode),
                                                          objUrlRule.PortalId,
                                                          GetNull(objUrlRule.TabId),
                                                          GetNull(objUrlRule.Parameters),
                                                          objUrlRule.RemoveTab,
                                                          objUrlRule.RuleAction,
                                                          GetNull(objUrlRule.Url),
                                                          GetNull(objUrlRule.RedirectDestination),
                                                          GetNull(objUrlRule.RedirectStatus)
                                                        );
                if (result != null)
                {
                    return (int)result;
                }
                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }


        public static void UpdateUrlRule(UrlRuleInfo objUrlRule)
        {
            DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery(ModuleQualifier + "UpdateUrlRule",
                                          objUrlRule.UrlRuleId,
                                          objUrlRule.DateTime,
                                          objUrlRule.UserId,
                                          objUrlRule.PortalId,
                                          objUrlRule.RuleType,
                                          GetNull(objUrlRule.CultureCode),
                                          GetNull(objUrlRule.TabId),
                                          GetNull(objUrlRule.Parameters),
                                          objUrlRule.RemoveTab,
                                          objUrlRule.RuleAction,
                                          GetNull(objUrlRule.Url),
                                          GetNull(objUrlRule.RedirectDestination),
                                          GetNull(objUrlRule.RedirectStatus)

                );

        }

        public static void DeleteUrlRule(int UrlRuleId)
        {
            DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery(ModuleQualifier + "DeleteUrlRule", UrlRuleId);

        }

        static public UrlRuleInfo GetUrlRule(int UrlRuleID)
        {
            return CBO.FillObject<UrlRuleInfo>(DotNetNuke.Data.DataProvider.Instance().ExecuteReader(ModuleQualifier + "GetUrlRule", UrlRuleID));
        }

        static public List<UrlRuleInfo> GetUrlRules(int PortalId)
        {
            return CBO.FillCollection<UrlRuleInfo>(DotNetNuke.Data.DataProvider.Instance().ExecuteReader(ModuleQualifier + "GetUrlRules", PortalId));
        }


        public static object GetNull(object Field)
        {
            return DotNetNuke.Common.Utilities.Null.GetNull(Field, DBNull.Value);
        }

    }


}