using System;

namespace Booler
{
    /// <summary>
    /// Исключения, характерные для создаваемых классов.
    /// </summary>
    namespace Exceptions
    {
        public class TokenizerException : ApplicationException
        {
            protected int index;
            public int Index => index;
            public TokenizerException(string message, int index) : base(message)
            {
                this.index = index;
            }
        }

        public class VariableGroupTokenException : TokenizerException
        {
            public VariableGroupTokenException(string message, int index) : base(message, index) { }
        }

        public class UnexpectedSymbolException : TokenizerException
        {
            public UnexpectedSymbolException(string message, int index) : base(message, index) { }
        }

        public class ParserException : ApplicationException
        {
            protected int index;
            public int Index => index;
            public ParserException(string message, int index) : base(message)
            {
                this.index = index;
            }
        }

        public class UnexpectedTokenException : ParserException
        {
            public UnexpectedTokenException(string message, int index) : base(message, index) { }
        }

        public class UnknownCodeMessageException : ApplicationException
        {
            protected int index;
            public int Index => index;
            public UnknownCodeMessageException(string message, int index) : base(message)
            {
                this.index = index;
            }
        }

        public class CodeException : ApplicationException
        {
            public CodeException(string message) : base(message) { }
        }

        public class MistakesNumberException : CodeException
        {
            public MistakesNumberException(string message) : base(message) { }
        }

        public class CodeGeneratingException : CodeException
        {
            public CodeGeneratingException(string message) : base(message) { }
        }
    }
}
