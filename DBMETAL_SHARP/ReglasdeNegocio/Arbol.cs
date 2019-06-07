using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReglasdeNegocio
{
    
    public class Arbol
    {
        public static void Llenar(TreeView Tree, SqlParameter[] Parametros, String SP_Consulta)
        {
            Tree.Nodes.Clear();
            try
            {
                SqlConnection objconexion;
                objconexion = Conexion.OpenConexion();
                SqlCommand Command = new SqlCommand(SP_Consulta, objconexion);
                Command.CommandType = CommandType.StoredProcedure;

                foreach (var item in Parametros)
                    Command.Parameters.Add(item).Value = item.Value;

                SqlDataAdapter da = new SqlDataAdapter(Command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //int j = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //TreeNode nodo = new TreeNode(dt.Rows[i]["Padre"].ToString());
                    //nodo.Nodes.Add(dt.Rows[i]["Hijo"].ToString());
                    TreeNode nodo = new TreeNode();
                    nodo.Tag = dt.Rows[i]["Codigo"].ToString();
                    nodo.Text = dt.Rows[i]["Nombre"].ToString();
                    //nodo.Nodes.Add(dt.Rows[i]["Hijo"].ToString()).Tag = dt.Rows[i]["Codigo"].ToString();

                    //j = i + 1;

                    //while ((j < dt.Rows.Count) && (dt.Rows[i]["Padre"].ToString() == dt.Rows[j]["Padre"].ToString()))
                    //{
                    //    if (j < dt.Rows.Count)
                    //        nodo.Nodes.Add(dt.Rows[j]["Hijo"].ToString()).Tag = dt.Rows[j]["Codigo"].ToString();
                    //    j++;
                    //}

                    //i = j - 1;

                    //i += 1;
                    Tree.Nodes.Add(nodo);
                }

            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message);
            }
        }
    }
}
