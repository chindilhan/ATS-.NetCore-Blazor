
using System.Collections.Generic;
using System.Linq;

namespace Stx.HRM
{

    public enum PageType
	{
        Home,
        Jobs,
        Candidate,
        TalentPool,
        Corporate,
        Recruit,
        Screening
    }


    public class PageBaseInfo
    {
        public PageBaseInfo()
        {

        }

        public PageBaseInfo(short pageUID, PageType pageType, string pageTitle, string newRecPageAdrs, string listRecPageAdrs, string reportPageAdrs)
        {
            PageUID = pageUID;
            PageType = pageType;
            PageTitle = pageTitle;
            NewRecPageAdrs = newRecPageAdrs;
            ListRecPageAdrs = listRecPageAdrs;
            ReportPageAdrs = reportPageAdrs;
        }

        public PageType PageType { get; set; }
        public short PageUID { get; set; }
        public string PageTitle { get; set; }
        public string NewRecPageAdrs { get; set; }
        public string ListRecPageAdrs { get; set; }
        public string ReportPageAdrs { get; set; }

        private static List<PageBaseInfo> pagelist = new List<PageBaseInfo>();

        //public static PageInfo IndexPages
        //{
        //    get { return new PageInfo("", PageRegistry.IndexPage, PageRegistry.IndexPage, ""); }
        //}
        
        public static PageBaseInfo GetPageInfo(short pageUid, PageType pageType, string pageTitle, int pageId = 0)
        {
            if (pagelist.Any(x => x.PageType == pageType))
            {
                return pagelist.First(x => x.PageType == pageType);
            }
            else
            {
                switch (pageType)
                {
                    case PageType.Jobs:
                        pagelist.Add( new PageBaseInfo(pageUid, pageType, pageTitle, "/Jobs/Create", "/Jobs/Dashboard", ""));
                        break;
                    case PageType.Candidate:
                        pagelist.Add(new PageBaseInfo(pageUid, pageType, pageTitle, "/Candidate/Create", "/Candidate/Search", ""));
                        break;
                    case PageType.TalentPool:
                        pagelist.Add(new PageBaseInfo(pageUid, pageType, pageTitle, "/Candidate/TalentPool", "/Candidate/TalentPool", ""));
                        break;
                    case PageType.Corporate:
                        pagelist.Add(new PageBaseInfo(pageUid, pageType, pageTitle, "/Corporate/Settings", "/Corporate/Settings", ""));
                        break;
                    case PageType.Recruit:
                        pagelist.Add(new PageBaseInfo(pageUid, pageType, pageTitle, "/Recruit/Dashboard", "/Recruit/Dashboard", ""));
                        break;
                    case PageType.Screening:
                        pagelist.Add(new PageBaseInfo(pageUid, pageType, pageTitle, "/Screening/Evaluate", "/Screening/Evaluate", ""));
                        break;
                    default:
                        break; ;
                }

                if (pagelist.Any(x => x.PageType == pageType)) 
                    return pagelist.First(x => x.PageType == pageType);
                else
                {
                   return new PageBaseInfo(0, PageType.Home, "", "/", "/", ""); //<< Add 'not found' page
                }

            }
        }

    }
}

