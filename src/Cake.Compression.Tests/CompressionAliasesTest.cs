using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Cake.Compression.Tests
{
	[TestFixture]
	public class CompressionAliasesTest
	{
		#region Private Constants
		private const ArchiveFormat InvalidFormat = (ArchiveFormat)int.MinValue;
		private const string ParamName = "ParamName";
		#endregion

		#region Private Fields
		private ICakeContext _context;
		private DirectoryPath _rootPath;
		private FilePath _outputPath;
		private ArchiveFormat _format;
		private ArchiveCompressSettings _settings;

		private FilePath _archiveFile;
		private DirectoryPath _archiveOutputPath;

		IEnumerable<FilePath> _filePaths;
		#endregion

		#region SetUp/TearDown
		[SetUp]
		public void SetUp()
		{
			_context = CreateContext();
			_rootPath = "/Root";
			_outputPath = "/archive.zip";
			_format = ArchiveFormat.Zip;

			_archiveFile = _outputPath;
		}

		[TearDown]
		public void TearDown()
		{
			_context = null;
			_rootPath = null;
			_outputPath = null;

			_archiveFile = null;
		}
		#endregion

		#region Tests
		[Test]
		public void Compress_Method_Throws_If_Context_Is_Null()
		{
			ICakeContext context = null;

			Assert.That(() => context.Compress(_rootPath, _outputPath, _filePaths, _format),
				Throws.InstanceOf<ArgumentNullException>()
				.And.Property(ParamName).EqualTo("context"));
		}

		[Test]
		public void Compress_Method_Throws_If_RootPath_Is_Null()
		{
			Assert.That(() => _context.Compress(null, _outputPath, _filePaths, _format),
				Throws.InstanceOf<ArgumentNullException>()
				.And.Property(ParamName).EqualTo("rootPath"));
		}

		[Test]
		public void Compress_Method_Throws_If_OutputhPath_Is_Null()
		{
			Assert.That(() => _context.Compress(_rootPath, null, _filePaths, _format),
					Throws.InstanceOf<ArgumentNullException>()
					.And.Property(ParamName).EqualTo("outputPath"));
		}

		[Test]
		public void Compress_Method_Throws_If_FilePaths_Is_Null()
		{
			Assert.That(() => _context.Compress(_rootPath, _outputPath, (IEnumerable<FilePath>)null, _format),
				Throws.InstanceOf<ArgumentNullException>()
				.And.Property(ParamName).EqualTo("filePaths"));
		}

		[Test]
		public void Compress_Method_Throws_If_Format_Is_Invalid()
		{
			Assert.That(() => _context.Compress(_rootPath, _outputPath, _filePaths, InvalidFormat),
				Throws.InstanceOf<InvalidEnumArgumentException>()
				.And.Property(ParamName).EqualTo("format"));
		}

		[Test]
		public void Uncompress_Method_Throws_If_Context_Is_Null()
		{
			ICakeContext context = null;

			Assert.That(() => context.Uncompress(_archiveFile, _archiveOutputPath, _format),
				Throws.InstanceOf<ArgumentNullException>()
				.And.Property(ParamName).EqualTo("context"));
		}

		[Test]
		public void Uncompress_Method_Throws_If_ArchiveFile_Is_Null()
		{
			Assert.That(() => _context.Uncompress(null, _archiveOutputPath, _format),
				Throws.InstanceOf<ArgumentNullException>()
				.And.Property(ParamName).EqualTo("archiveFile"));
		}

		[Test]
		public void Uncompress_Method_Throws_If_OutputPath_Is_Null()
		{
			Assert.That(() => _context.Uncompress(_archiveFile, null, _format),
				Throws.InstanceOf<ArgumentNullException>()
				.And.Property(ParamName).EqualTo("outputPath"));
		}

		[Test]
		public void Uncompress_Method_Throws_If_Format_Is_Invalid()
		{
			Assert.That(() => _context.Uncompress(_archiveFile, _archiveOutputPath, InvalidFormat),
				Throws.InstanceOf<InvalidEnumArgumentException>()
				.And.Property(ParamName).EqualTo("format"));
		}
		#endregion

		#region Private Methods
		private ICakeContext CreateContext()
		{
			var fileSystem = Substitute.For<IFileSystem>();
			var enviroment = Substitute.For<ICakeEnvironment>();
			var globber = Substitute.For<IGlobber>();
			var log = Substitute.For<ICakeLog>();
			var arguments = Substitute.For<ICakeArguments>();
			var processRunner = Substitute.For<IProcessRunner>();
			var registry = Substitute.For<IRegistry>();
			var tools = Substitute.For<IToolLocator>();

			var context = new CakeContext(
				fileSystem,
				enviroment,
				globber,
				log,
				arguments,
				processRunner,
				registry,
				tools);

			return context;
		}
		#endregion
	}
}