# FIPS 203 scaffold map

## Standard baseline

- Standard: [NIST FIPS 203, Module-Lattice-Based Key-Encapsulation Mechanism Standard](https://doi.org/10.6028/NIST.FIPS.203)
- Final publication date: 2024-08-13
- Errata status reviewed: 2026-08-15
- NIST source page: [FIPS 203 final publication](https://csrc.nist.gov/pubs/fips/203/final)

The scaffold follows the final FIPS 203 publication and NIST's published
potential corrections. The errata reviewed for this baseline clarify the
inclusion of `zeta^0 = 1` in Appendix A and correct the polynomial name in the
comment on Algorithm 15, line 7, from `v` to `w`. These corrections add no
cryptographic implementation to this repository.

Algorithms 1 and 2 are explanatory examples in the standard and intentionally
have no production stubs. Algorithms 3 through 21 are mapped below, but every
mapped cryptographic method remains `MAGIC` and throws
`NotImplementedException`.

## Shared constants and parameter sets

| Value | FIPS 203 value |
| --- | ---: |
| `N` | 256 |
| `Q` | 3329 |
| Shared secret key size | 32 bytes |

| Parameter set | k | eta1 | eta2 | du | dv | Encapsulation key | Decapsulation key | Ciphertext |
| --- | ---: | ---: | ---: | ---: | ---: | ---: | ---: | ---: |
| ML-KEM-512 | 2 | 3 | 2 | 10 | 4 | 800 bytes | 1632 bytes | 768 bytes |
| ML-KEM-768 | 3 | 2 | 2 | 10 | 4 | 1184 bytes | 2400 bytes | 1088 bytes |
| ML-KEM-1024 | 4 | 2 | 2 | 11 | 5 | 1568 bytes | 3168 bytes | 1568 bytes |

## Algorithm mapping

| FIPS 203 | Section | Procedure | Scaffold member |
| ---: | --- | --- | --- |
| 3 | 4.2.1 | `BitsToBytes` | `BitCodec.BitsToBytes` |
| 4 | 4.2.1 | `BytesToBits` | `BitCodec.BytesToBits` |
| 5 | 4.2.1 | `ByteEncode_d` | `ByteCodec.Encode` |
| 6 | 4.2.1 | `ByteDecode_d` | `ByteCodec.Decode` |
| 7 | 4.2.2 | `SampleNTT` | `Sampling.SampleNtt` |
| 8 | 4.2.2 | `SamplePolyCBD_eta` | `Sampling.SamplePolynomialCbd` |
| 9 | 4.3 | `NTT` | `Ntt.Forward` |
| 10 | 4.3 | `NTT^-1` | `Ntt.Inverse` |
| 11 | 4.3.1 | `MultiplyNTTs` | `Ntt.Multiply` |
| 12 | 4.3.1 | `BaseCaseMultiply` | `Ntt.BaseCaseMultiply` |
| 13 | 5.1 | `K-PKE.KeyGen` | `KPke.GenerateKeyPair` |
| 14 | 5.2 | `K-PKE.Encrypt` | `KPke.Encrypt` |
| 15 | 5.3 | `K-PKE.Decrypt` | `KPke.Decrypt` |
| 16 | 6.1 | `ML-KEM.KeyGen_internal` | `MlKemInternal.GenerateKeyPair` |
| 17 | 6.2 | `ML-KEM.Encaps_internal` | `MlKemInternal.Encapsulate` |
| 18 | 6.3 | `ML-KEM.Decaps_internal` | `MlKemInternal.Decapsulate` |
| 19 | 7.1 | `ML-KEM.KeyGen` | `MlKem512.GenerateKeyPair`, `MlKem768.GenerateKeyPair`, `MlKem1024.GenerateKeyPair` |
| 20 | 7.2 | `ML-KEM.Encaps` | `MlKem512.Encapsulate`, `MlKem768.Encapsulate`, `MlKem1024.Encapsulate` |
| 21 | 7.3 | `ML-KEM.Decaps` | `MlKem512.Decapsulate`, `MlKem768.Decapsulate`, `MlKem1024.Decapsulate` |

## Additional normative helpers

| FIPS 203 section | Concern | Scaffold member |
| --- | --- | --- |
| 4.1 | `H`, `G`, `J`, `PRF`, and `XOF` | `HashFunctions` |
| 4.2.1 | Compression and decompression | `Compression` |
| 7.2 | Encapsulation-key input checks | `InputValidation.ValidateEncapsulationKey` |
| 7.3 | Decapsulation input checks | `InputValidation.ValidateDecapsulationInputs` |

## ACVP policy

The initial scaffold contains only JSON DTOs, a loader, and skipped test slots.
No ACVP vectors are vendored. A later task must pin a specific release of
NIST's [ACVP-Server](https://github.com/usnistgov/ACVP-Server), record the tag
and hashes, and source `prompt.json` and `expectedResults.json` from that tag
rather than from the moving `master` branch.

