using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SecurityAccessQuery
{
    class ExportDefinition
    {
        /*
        Diagnostics function to enumerate all DLLs and get unique exported functions so that the signatures can be built

        This is what I have so far:

        GenerateKeyExOpt
        GetECUName
        GetConfiguredAccessTypes
        GetSeedLength
        GetKeyLength
        GenerateKeyEx

        GetComment 

        VectorCompressInit
        VectorCompress
        VectorCompressExit
        */

        public static void DumpUniqueExportsToConsole(string breakOnSpecificFunction = "")
        {
            HashSet<string> uniqueExports = new HashSet<string>();
            foreach (string filePath in Program.GetLibraryFiles())
            {
                List<string> exportsForFile = UnmanagedUtility.GetExports(filePath);
                foreach (string exportName in exportsForFile)
                {
                    if (exportName == breakOnSpecificFunction) 
                    {
                        Console.WriteLine($"BREAK: {breakOnSpecificFunction} for {Path.GetFileName(filePath)}");
                        Console.ReadLine();
                    }
                    uniqueExports.Add(exportName);
                }
                Console.WriteLine(filePath);
            }
            foreach (string uniqueExportName in uniqueExports)
            {
                Console.WriteLine(uniqueExportName);
            }
        }

        /*
        Compression - no public definitions : nothing found on https://kb.vector.com/
        
        VectorCompressInit
        VectorCompress
        VectorCompressExit

        // Compression libraries:
        CPC_NG_CompressAlgo1.dll
        CRR1_CompressAlgo1.dll
        DCB167_Compress.dll
        DCDC48_222_CompressAlgo1.dll
        DRVU_NG_CompressAlgo1.dll
        ESP213_CompressAlgo1.dll
        FCW177_Compress.dll
        FCW205_Compress.dll
        IC213_CompressAlgo1.dll
        IC222_CompressAlgo1.dll
        IC447KIG2_CompressAlgo1.dll
        IDC213_CompressAlgo1.dll
        ISG48V1_CompressAlgo1.dll
        LIB48_222_CompressAlgo1.dll
        RSG48V1_CompressAlgo1.dll
        UDCM_CompressAlgo1.dll
        VGSNAG3_CompressAlgo1.dll
        */


        /*
        GetComment : present in IC_204_* libraries such as IC_204_IC_204_01_51_11_00.dll
        Content is something like "Generiert fuer Hr Merz"
        */


        /*
        Standard functions:
         
        GenerateKeyExOpt
        GenerateKeyEx

        GetSeedLength
        GetKeyLength
        GetConfiguredAccessTypes
        GetECUName
        */

        /*
        GenerateKeyExOpt
        From Vector's official docs @ https://assets.vector.com/cms/content/know-how/_application-notes/AN-IDG-1-017_SecurityAccess.pdf
        
        VKeyGenResultEx GenerateKeyExOpt
        (
        const unsigned char* ipSeedArray,
        unsigned int iSeedArraySize,
        const unsigned int iSecurityLevel,
        const char* ipVariant,
        const char* ipOptions,
        unsigned char* iopKeyArray,
        unsigned int iMaxKeyArraySize,
        unsigned int& oActualKeyArraySize
        );
        Parameter description
        > [in] ipSeedArray: the seed queried by the ECU (as byte raw data)
        > [in] iSeedArraySize: The size of the array
        > [in] iSecurityLevel: the security level to be change to
        > [in] ipVariant: the ECU variant’s qualifier
        > [in] ipOptions: the option string (free text)
        > [out] iopKeyArray: the calculated key on return (as byte raw data)
        > [in] iMaxKeyArraySize: maximum number of key bytes available
        > [out] oActualKeyArraySize: the number of key bytes calculated

         */

        public static string[] KnownExportedFunctions = new string[] { "GetECUName", "GetComment", "GetKeyLength", "GetSeedLength", "GetConfiguredAccessTypes", "GenerateKeyExOpt", "GenerateKeyEx" };

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr GetECUName();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr GetComment();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int GetKeyLength(uint iSecurityLevel);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int GetSeedLength(uint iSecurityLevel);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int GetConfiguredAccessTypes(uint[] iSecurityLevels);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int GenerateKeyExOpt(byte[] ipSeedArray, uint iSeedArraySize, uint iSecurityLevel, byte[] ipVariant, byte[] ipOptions, byte[] iopKeyArray, uint iMaxKeyArraySize, out uint oActualKeyArraySize);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int GenerateKeyEx(byte[] ipSeedArray, uint iSeedArraySize, uint iSecurityLevel, byte[] ipVariant, byte[] iopKeyArray, uint iMaxKeyArraySize, out uint oActualKeyArraySize);

        public enum VKeyGenResultEx 
        {
            OK = 0,
            BufferTooSmall = 1,
            SecurityLevelInvalid = 2,
            VariantInvalid = 3,
            UnknownError = 4
        }
    }
}
