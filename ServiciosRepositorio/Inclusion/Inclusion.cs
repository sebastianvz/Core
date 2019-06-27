using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosRepositorio
{
    public class Inclusion : IInclusion
    {
        #region Private Attributes

        private readonly List<string> _inclusions;

        #endregion

        #region Constructor

        public Inclusion()
        {
            _inclusions = new List<string>();
        }
        #endregion

        #region Public Methods               
        public void AddInclusion(params string[] inclusions)
        {
            StringBuilder strBuilder = new StringBuilder();

            for (int index = 0; index < inclusions.Length; index++)
            {
                strBuilder.Append(index == inclusions.Length - 1 ? inclusions[index] : inclusions[index] + ".");
            }

            _inclusions.Add(strBuilder.ToString());
        }

        public void ClearInclusions()
        {
            _inclusions.Clear();
        }

        public string GetInclusions()
        {
            return string.Join(",", _inclusions);
        }
        #endregion
    }
}
