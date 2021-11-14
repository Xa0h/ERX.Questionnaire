using ERX.Questionnaire.DataAccess.Interfaces;
using ERX.Questionnaire.DataAccess.Services;
using ERX.Questionnaire.Services.Interfaces;
using ERX.Questionnaire.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERX.Questionnaire.Api.DI
{
    public class DependencyInjectionContainer
    {
        public static void RegisterServices(IServiceCollection servicesCollections)
        {
            servicesCollections.AddTransient<IUserService, UserService>();
            servicesCollections.AddTransient<IQuestionnaireService, QuestionnaireService>();
        }

        public static void RegisterRepositories(IServiceCollection servicesCollections)
        {
            servicesCollections.AddTransient<IUserData, UserData>();
            servicesCollections.AddTransient<IQuestionnaireData, QuestionnaireData>();
        }
    }
}
