namespace LibraryAPI.Domain.Enumerators;

[Flags]
public enum BookGenres
{
    None = 0,        // Nenhum gênero definido
    Fiction = 1 << 0,    // 1
    NonFiction = 1 << 1,    // 2
    Mystery = 1 << 2,    // 4
    Thriller = 1 << 3,    // 8
    Horror = 1 << 4,    // 16
    Fantasy = 1 << 5,    // 32
    ScienceFiction = 1 << 6,    // 64
    Historical = 1 << 7,    // 128
    Romance = 1 << 8,    // 256
    Adventure = 1 << 9,    // 512
    Biography = 1 << 10,   // 1024
    Autobiography = 1 << 11,   // 2048
    SelfHelp = 1 << 12,   // 4096
    Poetry = 1 << 13,   // 8192
    Drama = 1 << 14,   // 16384
    Philosophy = 1 << 15,   // 32768
    Psychology = 1 << 16,   // 65536
    Business = 1 << 17,   // 131072
    Economics = 1 << 18,   // 262144
    Politics = 1 << 19,   // 524288
    Religion = 1 << 20,   // 1048576
    Spirituality = 1 << 21,   // 2097152
    Science = 1 << 22,   // 4194304
    Mathematics = 1 << 23,   // 8388608
    Health = 1 << 24,   // 16777216
    Cooking = 1 << 25,   // 33554432
    Travel = 1 << 26,    // 67108864
    Art = 1 << 27,    // 134217728
    Music = 1 << 28,    // 268435456
    Education = 1 << 29,    // 536870912
    TrueCrime = 1 << 30,    // 1073741824
}