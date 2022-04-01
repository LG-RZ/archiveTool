## archiveTool
This application can be used to create and read IGA files.

## How To Use
Run the application in CMD and use the arguments listed below.

## Arguments
```
-d, --directory      The path of the Directory you want to archive.

-i, --iga            The path of the desired igArchive.

-p, --path           Required. The path of where you want to write an igArchive or extract files from an igArchive.

-c, --compression    (Default: 2) The desired compression mode for writing an igArchive:
                     0: No compression.
                     1: Zlib compression (average compression ratio, average decompression performance).
                     2: Lzma compression (best compression ratio, slowest decompression performance).
                     3: Lz4 compression (poorest compression ratio, fastest decompression performance).

-l, --logicalName    (Default: true) Use the logical name of the files when extracting from an igArchive.

--help               Display this help screen.
```

## Examples
* Extracting an IGA
`archiveTool.exe -iarchives/L101_NSanityBeach.pak -pExtracted`

* Creating an IGA
`archiveTool.exe -dFiles -pNewIGA.pak -c2`

## Credits
* AdventureT
* DTZxPorter
