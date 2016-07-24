using Cake.Common.IO;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using System.Collections.Generic;
using System.Linq;

namespace Cake.Compression
{
	/// <summary>
	/// Contains functionality related to compress files.
	/// </summary>
	[CakeAliasCategory("Compression")]
	public static class CompressionAliases
	{
		#region Public Methods
		public static void Compress(
			this ICakeContext context,
			DirectoryPath rootPath,
			FilePath outputPath,
			ArchiveFormat format)
		{
			Compress(context, rootPath, outputPath, format, null);
		}

		public static void Compress(
			this ICakeContext context,
			DirectoryPath rootPath,
			FilePath outputPath,
			ArchiveFormat format,
			ArchiveCompressSettings settings)
		{
			FilePathCollection filePaths = context.GetFiles(string.Concat(rootPath, "/**/*"));
			Compress(context, rootPath, outputPath, filePaths, format, settings);
		}

		public static void Compress(
			this ICakeContext context,
			DirectoryPath rootPath,
			FilePath outputPath,
			string pattern,
			ArchiveFormat format)
		{
			Compress(context, rootPath, outputPath, pattern, format, null);
		}

		public static void Compress(
			this ICakeContext context,
			DirectoryPath rootPath,
			FilePath outputPath,
			string pattern,
			ArchiveFormat format,
			ArchiveCompressSettings settings)
		{
			FilePathCollection filePaths = context.GetFiles(pattern);

			if (filePaths.Count == 0)
			{
				context.Log.Verbose("The provided pattern did not match any files.");
				return;
			}

			Compress(context, rootPath, outputPath, filePaths, format, settings);
		}

		public static void Compress(
			this ICakeContext context,
			DirectoryPath rootPath,
			FilePath outputPath,
			IEnumerable<FilePath> filePaths,
			ArchiveFormat format)
		{
			Compress(context, rootPath, outputPath, filePaths, format, null);
		}

		public static void Compress(
			this ICakeContext context,
			DirectoryPath rootPath,
			FilePath outputPath,
			IEnumerable<FilePath> filePaths,
			ArchiveFormat format,
			ArchiveCompressSettings settings)
		{
			Precondition.IsNotNull(context, nameof(context));
			Precondition.IsNotNull(rootPath, nameof(rootPath));
			Precondition.IsNotNull(outputPath, nameof(outputPath));
			Precondition.IsNotNull(filePaths, nameof(filePaths));
		}

		public static void Compress(
			this ICakeContext context,
			DirectoryPath rootPath,
			FilePath outputPath,
			IEnumerable<string> filePaths,
			ArchiveFormat format)
		{
			Compress(context, rootPath, outputPath, filePaths, format, null);
		}

		public static void Compress(
			this ICakeContext context,
			DirectoryPath rootPath,
			FilePath outputPath,
			IEnumerable<string> filePaths,
			ArchiveFormat format,
			ArchiveCompressSettings settings)
		{
			List<FilePath> paths = filePaths.Select(path => new FilePath(path)).ToList<FilePath>();
			Compress(context, rootPath, outputPath, paths, format, settings);
		}

		public static void Uncompress(
			this ICakeContext context,
			FilePath archiveFile,
			DirectoryPath outputPath,
			ArchiveFormat format)
		{
			Uncompress(context, archiveFile, outputPath, format, null);
		}

		public static void Uncompress(
			this ICakeContext context,
			FilePath archiveFile,
			DirectoryPath outputPath,
			ArchiveFormat format,
			ArchiveUncompressSettings settings)
		{
			Precondition.IsNotNull(context, nameof(context));
			Precondition.IsNotNull(archiveFile, nameof(archiveFile));
			Precondition.IsNotNull(outputPath, nameof(outputPath));
		}
		#endregion
	}
}