﻿using netDxf.Header;
using netDxf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using DxfToolLib.Schemas;
using DxfToolLib.Schemas.Core;

namespace DxfToolLib.Helpers;

internal class DxfParser : IDxfParser
{
    private readonly ISchemaFinder schemaFinder;

    public DxfParser(ISchemaFinder schemaFinder)
    {
        this.schemaFinder = schemaFinder;
    }

    private static DxfDocument? LoadUsingNetDxf(string filePath)
    {
        var dxfVersion = DxfDocument.CheckDxfFileVersion(filePath);
        // netDxf is only compatible with AutoCad2000 and higher DXF versions
        if (dxfVersion < DxfVersion.AutoCad2000) return null;
        // load file
        return DxfDocument.Load(filePath);
    }

    public string[] Parse(string dxfHighPointName, string[] inputLines)
    {
        var matches = schemaFinder.Matches(KnownSchemas.HighPointAutoCad2000.NAME, new Dictionary<string, string>{
            { KnownSchemas.HighPointAutoCad2000.FIELDS.TITLE, dxfHighPointName },
        }, inputLines);
        return matches;
    }

    public Encoding GetEncoding(string[] inputLines, Encoding defaultEncoding)
    {
        var matches = schemaFinder.Matches(KnownSchemas.CodePage.NAME, null, inputLines);
        var encodingName = matches.FirstOrDefault();

        if (encodingName == null)
        {
            return defaultEncoding;
        }
        var encodingText = encodingName.Split('_').Where((el, idx) => idx == 1).FirstOrDefault();
        if (encodingText == null)
        {
            return defaultEncoding;
        }
        if (Int32.TryParse(encodingText, out int encodingCodePage))
        {
            var encoding = CodePagesEncodingProvider.Instance.GetEncoding(encodingCodePage);
            if (encoding != null)
            {
                return encoding;
            }
        }
        return defaultEncoding;
    }

    public int GetVersion(string[] inputLines, int defaultValue = 0)
    {
        var matches = schemaFinder.Matches(KnownSchemas.CadVersion.NAME, null, inputLines);
        var versionName = matches.FirstOrDefault();
        if (versionName == null)
        {
            return defaultValue;
        }
        if (Int32.TryParse(versionName.AsSpan(2), out int version))
        {
            return version;
        }
        return defaultValue;
    }

    public int Parse(string dxfHighPointName, string filePath, string outputPath)
    {
        var header = File.ReadLines(filePath).Take(20).ToArray();

        var dxfEncoding = GetEncoding(header, Encoding.Default);
        var dxfVersion = GetVersion(header);

        if (dxfVersion > 1015)
        {
            var dxfDocument = LoadUsingNetDxf(filePath);
            if (dxfDocument != null)
            {
                Debug.WriteLine(dxfDocument.Entities.Texts.Count() + "");
            }
        } else {
            var inputLines = File.ReadAllLines(filePath, dxfEncoding);
            var outputLines = Parse(dxfHighPointName, inputLines);

            File.WriteAllLines(
                outputPath,
                outputLines
            );
            return outputLines.Length;
        }
        return 0;
    }
}