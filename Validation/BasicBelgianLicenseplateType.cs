namespace Validation;

public enum BasicBelgianLicenseType
{
    Type1, // Format: 1 → 28000
    Type2, // Format: 10000 → 30000
    Type3, // Format: 1 → 999999 or A-1 → L-9999
    Type4, // Format: 1 → 999999
    Type5, // Format: A.0001 or A.001.A or AA.001
    Type6, // Format: 001-AAA or AAA-001
    Type7  // Format: 1-AAA-001 or A-AAA-001 (currently used)
}