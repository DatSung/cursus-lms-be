using Cursus.LMS.Service.IService;
using Cursus.LMS.Service.Service;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Cursus.LMS.IntegrationTest.ServiceTest
{
    public static class TestServiceCollectionExtensions
    {
        public static IServiceCollection AddFirebaseServicesIfNeeded(this IServiceCollection services)
        {
            try
            {
                // Check if FirebaseApp.DefaultInstance is already initialized
                FirebaseApp app = FirebaseApp.DefaultInstance;
                // If DefaultInstance is not null, FirebaseApp is already initialized
            }
            catch (InvalidOperationException)
            {
                // FirebaseApp.DefaultInstance throws InvalidOperationException if not initialized
                var credentialPath = Path.Combine(Directory.GetCurrentDirectory(),
                    "cursus-lms-storage-firebase-adminsdk-51r7b-102f4637ef.json");

                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile(credentialPath)
                });

                services.AddSingleton(StorageClient.Create(GoogleCredential.FromFile(credentialPath)));

                services.AddScoped<IFirebaseService, FirebaseService>();
            }

            return services;
        }
    }
}
