using Cursus.LMS.Service.IService;
using Cursus.LMS.Service.Service;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;

namespace Cursus.LMS.API.Extentions;

public static class FirebaseServiceExtensions
{
    public static IServiceCollection AddFirebaseServices(this IServiceCollection services)
    {
        var credentialPath = Path.Combine(Directory.GetCurrentDirectory(),
            "cursus-lms-storage-firebase-adminsdk-51r7b-b7f2a96794.json");
        FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromFile(credentialPath)
        });
        services.AddSingleton(StorageClient.Create(GoogleCredential.FromFile(credentialPath)));
        services.AddScoped<IFirebaseService, FirebaseService>();
        return services;
    }
}