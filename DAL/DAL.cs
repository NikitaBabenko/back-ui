using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtbPortal.Backend.Core.Models;
using VtbPortal.Backend.DAL;
using VtbPortal.Backend.Loggers;

namespace DAL
{
    public class DAL
    {
        #region readonly fields

        private readonly Container container;
        private readonly IFeedbackRepository feedbackRepo;
        private readonly IShareholderAccountRepository shareholderRepo;
        private readonly IVtbPortalLogger logger;


        #endregion

        #region constructures

        public DAL()
        {
            container = Bootstrapper.Initialize();
            logger = container.GetInstance<IVtbPortalLogger>();
            feedbackRepo = container.GetInstance<IFeedbackRepository>();
            shareholderRepo = container.GetInstance<IShareholderAccountRepository>();
        }

        #endregion

        public IEnumerable<FeedbackForm> GetAllFeedbackForms()
        {
            return GetFeedbackFormsByFilter(null, null, null, null);
        }





        public IEnumerable<FeedbackForm> GetFeedbackFormsByFilter(string startDate, string endDate, string feedbackFormId, string search)
        {
            var result = new List<FeedbackForm>();
            try
            {
                DateTime sDate;
                DateTime eDate;
                int formId;
                if (!DateTime.TryParse(startDate, out sDate))
                {
                    sDate = DateTime.MinValue;
                }
                if (!DateTime.TryParse(endDate, out eDate))
                {
                    eDate = DateTime.MaxValue;
                }
                int.TryParse(feedbackFormId, out formId);
                var r1 = feedbackRepo.GetFormsForPeriod(sDate, eDate);
                var r2 = r1.Where(f => formId == 0 || f.FormId == formId);
                var r3 = r2.Where(
                               f =>
                                   string.IsNullOrWhiteSpace(search) || f.FormTitle.Contains(search) || f.Ip.Contains(search)
                                   || f.UserAgent.Contains(search) || f.FeedbackFormFields.Any(fff => fff.FieldValue.Contains(search)));
                var r4 = r3.ToList();
                result = r4;
                    
                        //.Select(FeedbackFormMapper.Map)
                        
                        
                        
            }
            catch (FormatException fex)
            {
                logger.Error(fex, "Get feedback forms by date sended incorrect date parameter.");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Get feedback forms by date throw exception.");
            }
            return result;
        }


    }

    

}
