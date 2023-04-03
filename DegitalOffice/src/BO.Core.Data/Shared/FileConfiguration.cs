namespace BO.Core.DataCommon.Shared
{
    public static class FileConfiguration
    {
        // For more file signatures, see the File Signatures Database (https://www.filesignatures.net/)
        // and the official specifications for the file types you wish to add.

        public static readonly Dictionary<string, List<byte[]>> FileSignature = new Dictionary<string, List<byte[]>>
        {
            {".png", new List<byte[]> {new byte[] {0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A}}},
            {
                ".jpeg", new List<byte[]>
                {
                    new byte[] {0xFF, 0xD8, 0xFF, 0xE0},
                    new byte[] {0xFF, 0xD8, 0xFF, 0xE2},
                    new byte[] {0xFF, 0xD8, 0xFF, 0xE3},
                }
            },
            {
                ".jpg", new List<byte[]>
                {
                    new byte[] {0xFF, 0xD8, 0xFF, 0xE0},
                    new byte[] {0xFF, 0xD8, 0xFF, 0xE1},
                    new byte[] {0xFF, 0xD8, 0xFF, 0xE8},
                }
            },
            {
                ".doc", new List<byte[]>
                {
                    new byte[] {0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1},
                    new byte[] {0x0D, 0x44, 0x4F, 0x43},
                    new byte[] {0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1, 0x00},
                    new byte[] {0xDB, 0xA5, 0x2D, 0x00},
                    new byte[] {0xEC, 0xA5, 0xC1, 0x00}
                }
            },
            {
                ".docx", new List<byte[]>
                {
                    new byte[] {0x50, 0x4B, 0x03, 0x04},
                    new byte[] {0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00}
                }
            },
            {
                ".xls", new List<byte[]>
                {
                    new byte[] {0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1},
                    new byte[] {0x09, 0x08, 0x10, 0x00, 0x00, 0x06, 0x05, 0x00},
                    new byte[] {0xFD, 0xFF, 0xFF, 0xFF, 0x10},
                    new byte[] {0xFD, 0xFF, 0xFF, 0xFF, 0x1F},
                    new byte[] {0xFD, 0xFF, 0xFF, 0xFF, 0x22},
                    new byte[] {0xFD, 0xFF, 0xFF, 0xFF, 0x23},
                    new byte[] {0xFD, 0xFF, 0xFF, 0xFF, 0x28},
                    new byte[] {0xFD, 0xFF, 0xFF, 0xFF, 0x29}
                }
            },
            {
                ".xlsx", new List<byte[]>
                {
                    new byte[] {0x50, 0x4B, 0x03, 0x04},
                    new byte[] {0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00}
                }
            },
            {
                ".pdf", new List<byte[]>
                {
                    new byte[] {0x25, 0x50, 0x44, 0x46}
                }
            }
        };

        public static string[] Fonts =
        {
            "OpenSans-Bold.ttf",
            "OpenSans-BoldItalic.ttf",
            "OpenSans-ExtraBold.ttf",
            "OpenSans-ExtraBoldItalic.ttf",
            "OpenSans-Light.ttf",
            "OpenSans-Italic.ttf",
            "OpenSans-LightItalic.ttf",
            "OpenSans-SemiBold.ttf",
            "OpenSans-SemiBoldItalic.ttf",
            "OpenSans-Regular.ttf"
        };
    }
}
