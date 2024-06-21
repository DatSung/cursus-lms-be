using Cursus.LMS.Service.IService;
using Cursus.LMS.Service.Service;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;

public static class FirebaseServiceExtensions
{
    private static Lazy<FirebaseApp> _firebaseApp = new Lazy<FirebaseApp>(InitializeFirebaseApp);
    private static Lazy<StorageClient> _storageClient = new Lazy<StorageClient>(InitializeStorageClient);

    public static IServiceCollection AddFirebaseServices(this IServiceCollection services)
    {
        services.AddSingleton(_storageClient.Value);
        services.AddScoped<IFirebaseService, FirebaseService>();
        return services;
    }

    private static FirebaseApp InitializeFirebaseApp()
    {
        var credentialPath = Path.Combine(Directory.GetCurrentDirectory(),
            "cursus-lms-storage-firebase-adminsdk-51r7b-102f4637ef.json");

        FirebaseApp firebaseApp = FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromFile(credentialPath),
        });

        return firebaseApp;
    }

    private static StorageClient InitializeStorageClient()
    {
        var credentialPath = Path.Combine(Directory.GetCurrentDirectory(),
            "cursus-lms-storage-firebase-adminsdk-51r7b-102f4637ef.json");

        var storageClient = StorageClient.Create(GoogleCredential.FromFile(credentialPath));

        return storageClient;
    }
}
