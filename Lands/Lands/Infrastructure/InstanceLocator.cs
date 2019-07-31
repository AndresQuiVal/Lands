using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.Infrastructure
{
    using ViewsModels;
    class InstanceLocator // clase que nos instanciará la locación
    {
        #region Properties
        public MainViewModel Main { get; set; }

        #endregion

        #region Constructors
        public InstanceLocator()
        {
            this.Main = new MainViewModel(); // ligar la pagina login a la mainviewmodel
        }
        #endregion

    }

}
