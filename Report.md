```

BenchmarkDotNet v0.15.2, Linux Manjaro Linux
Intel Core i7-10700F CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.110
  [Host]     : .NET 9.0.9 (9.0.925.41916), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.9 (9.0.925.41916), X64 RyuJIT AVX2


```
| Method                      | N    | Mean         | Error      | StdDev     | Ratio | RatioSD |
|---------------------------- |----- |-------------:|-----------:|-----------:|------:|--------:|
| **HashCodeFast**                | **10**   |     **1.776 ns** |  **0.0044 ns** |  **0.0039 ns** |  **1.00** |    **0.00** |
| HashCode                    | 10   |     4.122 ns |  0.0145 ns |  0.0121 ns |  2.32 |    0.01 |
| HashCodeCaseInsensitiveFast | 10   |     8.193 ns |  0.0314 ns |  0.0262 ns |  4.61 |    0.02 |
| HashCodeCaseInsensitive     | 10   |     7.370 ns |  0.0246 ns |  0.0205 ns |  4.15 |    0.01 |
|                             |      |              |            |            |       |         |
| **HashCodeFast**                | **11**   |     **2.148 ns** |  **0.0134 ns** |  **0.0125 ns** |  **1.00** |    **0.01** |
| HashCode                    | 11   |     4.543 ns |  0.0272 ns |  0.0241 ns |  2.11 |    0.02 |
| HashCodeCaseInsensitiveFast | 11   |     8.410 ns |  0.0387 ns |  0.0323 ns |  3.92 |    0.03 |
| HashCodeCaseInsensitive     | 11   |     8.293 ns |  0.0869 ns |  0.0813 ns |  3.86 |    0.04 |
|                             |      |              |            |            |       |         |
| **HashCodeFast**                | **12**   |     **2.145 ns** |  **0.0123 ns** |  **0.0116 ns** |  **1.00** |    **0.01** |
| HashCode                    | 12   |     4.982 ns |  0.0251 ns |  0.0223 ns |  2.32 |    0.02 |
| HashCodeCaseInsensitiveFast | 12   |     8.396 ns |  0.0435 ns |  0.0386 ns |  3.91 |    0.03 |
| HashCodeCaseInsensitive     | 12   |     8.439 ns |  0.0928 ns |  0.0823 ns |  3.93 |    0.04 |
|                             |      |              |            |            |       |         |
| **HashCodeFast**                | **13**   |     **2.420 ns** |  **0.0093 ns** |  **0.0073 ns** |  **1.00** |    **0.00** |
| HashCode                    | 13   |     5.486 ns |  0.0155 ns |  0.0129 ns |  2.27 |    0.01 |
| HashCodeCaseInsensitiveFast | 13   |     9.801 ns |  0.0393 ns |  0.0348 ns |  4.05 |    0.02 |
| HashCodeCaseInsensitive     | 13   |     9.228 ns |  0.0552 ns |  0.0490 ns |  3.81 |    0.02 |
|                             |      |              |            |            |       |         |
| **HashCodeFast**                | **100**  |    **19.762 ns** |  **0.1014 ns** |  **0.0899 ns** |  **1.00** |    **0.01** |
| HashCode                    | 100  |    60.330 ns |  0.1821 ns |  0.1614 ns |  3.05 |    0.02 |
| HashCodeCaseInsensitiveFast | 100  |    49.401 ns |  0.0886 ns |  0.0785 ns |  2.50 |    0.01 |
| HashCodeCaseInsensitive     | 100  |    63.502 ns |  0.3411 ns |  0.2848 ns |  3.21 |    0.02 |
|                             |      |              |            |            |       |         |
| **HashCodeFast**                | **101**  |    **20.303 ns** |  **0.1179 ns** |  **0.0984 ns** |  **1.00** |    **0.01** |
| HashCode                    | 101  |    60.925 ns |  0.1462 ns |  0.1221 ns |  3.00 |    0.02 |
| HashCodeCaseInsensitiveFast | 101  |    51.451 ns |  0.1523 ns |  0.1272 ns |  2.53 |    0.01 |
| HashCodeCaseInsensitive     | 101  |    64.313 ns |  0.6719 ns |  0.5957 ns |  3.17 |    0.03 |
|                             |      |              |            |            |       |         |
| **HashCodeFast**                | **102**  |    **20.424 ns** |  **0.2260 ns** |  **0.2114 ns** |  **1.00** |    **0.01** |
| HashCode                    | 102  |    61.722 ns |  0.3582 ns |  0.3176 ns |  3.02 |    0.03 |
| HashCodeCaseInsensitiveFast | 102  |    51.091 ns |  0.0838 ns |  0.0700 ns |  2.50 |    0.03 |
| HashCodeCaseInsensitive     | 102  |    65.796 ns |  0.3988 ns |  0.3535 ns |  3.22 |    0.04 |
|                             |      |              |            |            |       |         |
| **HashCodeFast**                | **103**  |    **20.886 ns** |  **0.2671 ns** |  **0.2368 ns** |  **1.00** |    **0.02** |
| HashCode                    | 103  |    62.315 ns |  0.2391 ns |  0.2237 ns |  2.98 |    0.03 |
| HashCodeCaseInsensitiveFast | 103  |    50.524 ns |  0.1101 ns |  0.1030 ns |  2.42 |    0.03 |
| HashCodeCaseInsensitive     | 103  |    66.302 ns |  0.4114 ns |  0.3848 ns |  3.17 |    0.04 |
|                             |      |              |            |            |       |         |
| **HashCodeFast**                | **1000** |   **263.210 ns** |  **0.9788 ns** |  **0.8677 ns** |  **1.00** |    **0.00** |
| HashCode                    | 1000 |   641.243 ns |  1.4658 ns |  1.1444 ns |  2.44 |    0.01 |
| HashCodeCaseInsensitiveFast | 1000 |   473.327 ns |  2.5820 ns |  2.2889 ns |  1.80 |    0.01 |
| HashCodeCaseInsensitive     | 1000 | 1,769.096 ns |  8.7526 ns |  7.3088 ns |  6.72 |    0.03 |
|                             |      |              |            |            |       |         |
| **HashCodeFast**                | **1001** |   **264.122 ns** |  **1.2191 ns** |  **1.0807 ns** |  **1.00** |    **0.01** |
| HashCode                    | 1001 |   641.435 ns |  1.6214 ns |  1.5167 ns |  2.43 |    0.01 |
| HashCodeCaseInsensitiveFast | 1001 |   483.084 ns |  2.7563 ns |  2.4434 ns |  1.83 |    0.01 |
| HashCodeCaseInsensitive     | 1001 | 1,784.493 ns | 15.9319 ns | 14.9027 ns |  6.76 |    0.06 |
|                             |      |              |            |            |       |         |
| **HashCodeFast**                | **1002** |   **264.910 ns** |  **1.4997 ns** |  **1.4028 ns** |  **1.00** |    **0.01** |
| HashCode                    | 1002 |   642.752 ns |  1.2461 ns |  1.0405 ns |  2.43 |    0.01 |
| HashCodeCaseInsensitiveFast | 1002 |   482.210 ns |  1.5749 ns |  1.3961 ns |  1.82 |    0.01 |
| HashCodeCaseInsensitive     | 1002 | 1,840.528 ns |  8.1865 ns |  7.2571 ns |  6.95 |    0.04 |
|                             |      |              |            |            |       |         |
| **HashCodeFast**                | **1003** |   **264.310 ns** |  **0.5364 ns** |  **0.4188 ns** |  **1.00** |    **0.00** |
| HashCode                    | 1003 |   641.792 ns |  1.6393 ns |  1.3689 ns |  2.43 |    0.01 |
| HashCodeCaseInsensitiveFast | 1003 |   476.801 ns |  2.3717 ns |  2.2185 ns |  1.80 |    0.01 |
| HashCodeCaseInsensitive     | 1003 | 1,791.584 ns | 14.0366 ns | 13.1299 ns |  6.78 |    0.05 |
