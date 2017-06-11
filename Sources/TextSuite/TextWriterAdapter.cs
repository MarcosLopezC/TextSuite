using System;
using System.IO;
using System.Text;

namespace TextSuite
{
	/// <summary>
	/// Represents an TextWriter that writers its output into another TextWriter.
	/// </summary>
	public abstract class TextWriterAdapter : TextWriter
	{
		protected TextWriter innerWriter;

		/// <summary>
		/// Gets or sets the writer onto which the output is written.
		/// </summary>
		public TextWriter InnerWriter
		{
			get
			{
				return innerWriter;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException(nameof(value));
				}

				innerWriter = value;
			}
		}

		/// <summary>
		/// Gets or sets the enconding used to write the text.
		/// </summary>
		public override Encoding Encoding
		{
			get
			{
				return innerWriter.Encoding;
			}
		}

		/// <summary>
		/// Gets or sets the line terminator string.
		/// </summary>
		public override string NewLine
		{
			get
			{
				return innerWriter.NewLine;
			}
			set
			{
				innerWriter.NewLine = value;
			}
		}

		/// <summary>
		/// Initializes a new instance of TextWriterAdapter.
		/// </summary>
		/// <param name="innerWriter">The TextWriter onto which the output will be written.</param>
		public TextWriterAdapter(TextWriter innerWriter)
		{
			this.innerWriter = innerWriter;
		}

		/// <summary>
		/// Closes the current writer and releases any system resources associated with the writer.
		/// </summary>
		public override void Close()
		{
			innerWriter.Close();
		}

		/// <summary>
		/// Clears all buffers for the current writer and causes any buffered data to be written.
		/// </summary>
		public override void Flush()
		{
			innerWriter.Flush();
		}

		/// <summary>
		/// Writes a character to the InnerWriter.
		/// </summary>
		/// <param name="value">The character to be written.</param>
		public override void Write(char value)
		{
			innerWriter.Write(value);
		}
	}
}
