// using EncryptSolution;
// using System.Threading.Tasks;
//
// namespace ProductApi.Services
// {
//     public class EncryptionService
//     {
//         public EncryptionService()
//         {
//             // Initialize once with your secret key
//             EncryptionHelper.Initialize("MySecretKey123");
//         }
//
//
//         /// Encrypt all [EncryptField] properties in any object
//         public Task<T> EncryptAsync<T>(T obj)
//         {
//             EncryptionHelper.EncryptObject(obj);
//             return Task.FromResult(obj);
//         }
//
//
//         /// Decrypt all [EncryptField] properties in any object
//         public Task<T> DecryptAsync<T>(T obj)
//         {
//             EncryptionHelper.DecryptObject(obj);
//             return Task.FromResult(obj);
//         }
//
//      
//         /// Encrypt all [EncryptField] properties in a list
//      
//         public Task<List<T>> EncryptListAsync<T>(List<T> list)
//         {
//             foreach (var item in list)
//                 EncryptionHelper.EncryptObject(item);
//
//             return Task.FromResult(list);
//         }
//
//
//         /// Decrypt all [EncryptField] properties in a list
//         public Task<List<T>> DecryptListAsync<T>(List<T> list)
//         {
//             foreach (var item in list)
//                 EncryptionHelper.DecryptObject(item);
//
//             return Task.FromResult(list);
//         }
//     }
// }