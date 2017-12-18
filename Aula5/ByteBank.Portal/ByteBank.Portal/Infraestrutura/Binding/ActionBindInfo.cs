using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura.Binding
{
    public class ActionBindInfo
    {
        public MethodInfo MethodInfo { get; private set; }
        public IReadOnlyCollection<ArgumentoNomeValor> TuplasArgumentoNomeValor { get; private set; }

        public ActionBindInfo(MethodInfo methodInfo, IEnumerable<ArgumentoNomeValor> tuplasArgumentoNomeValor)
        {
            MethodInfo = methodInfo ?? throw new ArgumentNullException(nameof(MethodInfo));

            if (tuplasArgumentoNomeValor == null)
                throw new ArgumentNullException(nameof(tuplasArgumentoNomeValor));

            TuplasArgumentoNomeValor = 
                new ReadOnlyCollection<ArgumentoNomeValor>(tuplasArgumentoNomeValor.ToList());
        }


        public object Invoke(object controller)
        {
            var countParametros = TuplasArgumentoNomeValor.Count;
            var possuiArgumentos = countParametros > 0;

            if(!possuiArgumentos)
                return MethodInfo.Invoke(controller, new object[0]);

            var parametrosMethodInfo = MethodInfo.GetParameters();
            var parametrosInvoke = new object[countParametros];

            for (int i = 0; i < countParametros; i++)
            {
                var parametro = parametrosMethodInfo[i];
                var parametroNome = parametro.Name;

                var argumento = TuplasArgumentoNomeValor.Single(tupla => tupla.Nome == parametroNome);

                parametrosInvoke[i] = Convert.ChangeType(argumento.Valor, parametro.ParameterType);
            }

            return MethodInfo.Invoke(controller, parametrosInvoke);
        }
    }
}
