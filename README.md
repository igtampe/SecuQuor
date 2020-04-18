# SecuQuor

SecuQuor is a small text encryption utility. I recently *completely reworked it* so that it can be easily modified to add more encryption methods, by using the IEncryptionHandler interface.

SecuQuor comes bundled with an "encryptor" that will translate text into Morse Code, and the SecuQuor Encryption method which I made.

## SecuQuor Encryption
SecuQuor Encryption works by translating text into a long string of segments by using a built in codewheel, and a provided Key and Shift register. An example is below for the phrase `Hello! This is a test.` using key `970-953-957-B40` and shift `3`:

```AB9700-AA14550-AA4850-AA4850-AA3880-CB15312-CA23925-BB5718-AA9700-AA15520-BA11436-CA23925-AA15520-BA11436-CA23925-AA10670-CA23925-BA5718-AA14550-BA11436-BA5718-CA8613```

Take the segment `AB9700`, which represents `H`. There are two portions to this segment, the SegmentSection and SegmentNumber.
SecuQuor splits characters into three different sections (A, B, and C) with two subdivisions (A and B). These subsections are used to define lowercase (A) and uppercase (B) alphabetical characters in sections A and B, which represent characters A through O and P through Z respectively. Section C is reserved for symbols.

Depending on what section (A B or C), SecuQuor will divide (when decrypting) the SegmentNumber by first, second, or third number in the key, respectively.

Once it's done this, we know `AB9700` is actually `AB10`. However, we are missing one last step, which is our shift register. This register was added in this revision of SecuQuor Encryption. Since our shift is `3`, the segment number is actually 10-3, which means we have to look up `AB7`. 

Looking that up in the CodeWheel, we get that `AB7` represents `H`.

### SecuQuor Keys
SecuQuor's Keys are of either 3 or 4 segments. The first 3 segments contain 3 numbers, however the 4th is a hexadecimal number, which is a sort of *checksum* for the code (calculated by adding the three first segments). The 4th segment is optional, however, so you can use a signed code as an unsigned code by just removing the signature.

#### Four Digit SecuQuor Keys
SecuQuor Encryption V3 ads 4 digit keys, which require signatures, and have a new signature generating calculation (K1+2K2+3K3)
