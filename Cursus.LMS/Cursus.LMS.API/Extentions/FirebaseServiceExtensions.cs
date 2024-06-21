using Cursus.LMS.Service.IService;
using Cursus.LMS.Service.Service;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;

public static class FirebaseServiceExtensions
{
    private static bool _firebaseInitialized = false;

    public static IServiceCollection AddFirebaseServices(this IServiceCollection services)
    {
        if (!_firebaseInitialized)
        {
            var credentialPath = Path.Combine(Directory.GetCurrentDirectory(),
                "cursus-lms-storage-firebase-adminsdk-51r7b-102f4637ef.json");

            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(credentialPath)
            });

            services.AddSingleton(StorageClient.Create(GoogleCredential.FromFile(credentialPath)));

            _firebaseInitialized = true;
        }

        services.AddScoped<IFirebaseService, FirebaseService>();
        return services;
    }
}
