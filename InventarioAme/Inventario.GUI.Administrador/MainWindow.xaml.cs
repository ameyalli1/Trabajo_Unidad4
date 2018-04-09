using Inventario.BIZ;
using Inventario.COMMON.Entidades;
using Inventario.COMMON.Interfaces;
using Inventario.DAL;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Inventario.GUI.Administrador
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

     

        List<venta> venta;
     
        bool n;
        enum accion
        {
            Nuevo,
            Editar
        }
        IManejadorEmpleados manejadorEmpleados;
        IManejadorProductos manejadorProductos;
        IManejadorClientes manejadorClientes;
        IManejadorCategoria manejadorCategoria;
       IManejadorVenta manejadorVenta;


        accion accionn;

        public MainWindow()
        {
            InitializeComponent();
            venta = new List<venta>();
          //  Venta2 = new List<ReporteGeneral>();
            manejadorEmpleados = new ManejadorEmpleados(new RepositorioDeEmpleados());
            manejadorProductos = new ManejadorProductos(new RepositorioDeProductos());
            manejadorClientes = new ManejadorClientes(new RepositorioDeClientes());
            manejadorCategoria = new ManejadorCategorias(new RepositorioDeCategoria());
            manejadorVenta = new ManejadorVenta(new RepositorioDeVenta());

            //para llenar las listas desplegables 

           // cmbProductosCategoria.ItemsSource = manejadorCategoria.Listar;
            //cmbCliente.ItemsSource = manejadorClientes.Listar;
            //cmbEmpleado.ItemsSource = manejadorEmpleados.Listar;



            CargarFormularioVenta();

            
        
           


 //Empleados
            PonerBotonesEmpleadosEnEdicion(false);
            LimpiarCamposDeEmpleados();
            ActualizarTablaEmpleados();
//Productos
            PonerBotonesProductosEnEdicion(false);
            LimpiarCamposDeProductos();
            ActualizarTablaProductos();
//Categoria
            PonerBotonesCategoriaEnEdicion(false);
            LimpiarCamposDeCategoria();
            ActualizarTablaCategoria();
 //Cliente
            PonerBotonesClienteEnEdicion(false);
            LimpiarCamposDeClientes();
            ActualizarTablaClientes();
 //Venta
            PonerBotonesVentaEnEdicion(true);
            NuevaVenta2(false);
            HabilitarcajasVenta(true);
            CargarFormularioVenta();

        }


//Empleados
        private void ActualizarTablaEmpleados()
        {
            dtgEmpleados.ItemsSource = null;
            dtgEmpleados.ItemsSource = manejadorEmpleados.Listar;
            cmbEmpleado.ItemsSource = manejadorEmpleados.Listar;

        }
        private void LimpiarCamposDeEmpleados()
        {
            txbEmpleadosNombre.Clear();
            txbEmpleadosDireccion.Clear();
            txbEmpleadosRfc.Clear();
            txbEmpleadosTelefono.Clear();
            txbEmpleadosCorreo.Clear();
            txbEmpleadosSueldo.Clear();
            txbEmpleadosId.Text = "";
            txbEmpleadosArea.Clear();
        }
        private void PonerBotonesEmpleadosEnEdicion(bool value)
        {
            btnEmpleadosCancelar.IsEnabled = value;
            btnEmpleadosEditar.IsEnabled = !value;
            btnEmpleadosEliminar.IsEnabled = !value;
            btnEmpleadosGuardar.IsEnabled = value;
            btnEmpleadosNuevo.IsEnabled = !value;
        }
//Productos
        private void ActualizarTablaProductos()
        {
            dtgProductos.ItemsSource = null;
            dtgProductos.ItemsSource = manejadorProductos.Listar;
           
         
        }
        private void LimpiarCamposDeProductos()
        {
            txbProductosNombre.Clear();
            // txbProductosCategoria.Clear();
            txbProductosDescripcion.Clear();
            txbProductosPrecioVenta.Clear();
            txbProductosPrecioCompra.Clear();
            txbProductosId.Text = "";
            txbProductosPresentacion.Clear();


        }
        private void PonerBotonesProductosEnEdicion(bool value)
        {
            btnProductosCancelar.IsEnabled = value;
            btnProductosEditar.IsEnabled = !value;
            btnProductosEliminar.IsEnabled = !value;
            btnProductosGuardar.IsEnabled = value;
            btnProductosNuevo.IsEnabled = !value;
        }
//Cliente
        private void ActualizarTablaClientes()
        {
            dtgClientes.ItemsSource = null;
            dtgClientes.ItemsSource = manejadorClientes.Listar;
            cmbCliente.ItemsSource = manejadorClientes.Listar;
        }
        private void LimpiarCamposDeClientes()
        {
            txbClientesNombre.Clear();
            txbClientesDireccion.Clear();
            txbClientesRfc.Clear();
            txbClientesTelefono.Clear();
            txbClientesId.Text = "";
            txbClientesCorreo.Clear();


        }
        private void PonerBotonesClienteEnEdicion(bool value)
        {
            btnClientesCancelar.IsEnabled = value;
            btnClientesEditar.IsEnabled = !value;
            btnClientesEliminar.IsEnabled = !value;
            btnClientesGuardar.IsEnabled = value;
            btnClientesNuevo.IsEnabled = !value;
        }
//Categoria
        private void ActualizarTablaCategoria()
        {
            dtgCategoria.ItemsSource = null;
            dtgCategoria.ItemsSource = manejadorCategoria.Listar;
            cmbProductosCategoria.ItemsSource = manejadorCategoria.Listar;
        }
        private void LimpiarCamposDeCategoria()
        {
            txbCategoriaCategoria.Clear();
            txbCategoriaId.Text = "";



        }
        private void PonerBotonesCategoriaEnEdicion(bool value)
        {
            btnCategoriaCancelar.IsEnabled = value;
            btnCategoriaEditar.IsEnabled = !value;
            btnCategoriaEliminar.IsEnabled = !value;
            btnCategoriaGuardar.IsEnabled = value;
            btnCategoriaNuevo.IsEnabled = !value;
        }
//Venta
        private void CargarFormularioVenta()
        {

            txbFecha.Text = DateTime.Now.ToShortDateString();
            dtgInventario.ItemsSource = null;
            dtgInventario.ItemsSource = manejadorProductos.Listar;

            cmbCliente.ItemsSource = manejadorClientes.Listar;
            cmbEmpleado.ItemsSource = manejadorEmpleados.Listar;

            AgregarTablaLista();
            dtgListaProductos.ItemsSource = null;
            dtgListaProductos.ItemsSource = manejadorProductos.Listar;
            AgregarTablaLista();
            Random a = new Random();
            int p = a.Next(0, 80000);
            txbFolio.Text = p.ToString();

        }
        private void PonerBotonesVentaEnEdicion(bool value)
        {
            btnAgregar.IsEnabled = !value;
            btnNuevaVenta.IsEnabled = !value;
            btnEditar.IsEnabled = !value;
            btnCancelar.IsEnabled = !value;
            btnEliminar.IsEnabled = !value;
            btnVenta.IsEnabled = !value;
        }
        private void NuevaVenta2(bool value)
        {
            btnNuevaVenta.IsEnabled = !value;
            HabilitarcajasVenta(false);
        }
        private void HabilitarcajasVenta(bool value)
        {

            txbFecha.Clear();
            txbFolio.Clear();
            // txbCliente.Clear();
            //txbEmpleado.Clear();
            txbCantidad.Clear();

            txbFecha.IsEnabled = !value;
            txbFolio.IsEnabled = !value;
            cmbCliente.IsEnabled = !value;
            cmbEmpleado.IsEnabled = !value;
            txbCantidad.IsEnabled = !value;
        }



     


        private void btnEmpleadosNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeEmpleados();
            PonerBotonesEmpleadosEnEdicion(true);
            accionn = accion.Nuevo;
        }

        private void btnEmpleadosEditar_Click(object sender, RoutedEventArgs e)
        {

            Empleado emp = dtgEmpleados.SelectedItem as Empleado;
            if (emp != null)
            {
                txbEmpleadosId.Text = emp.Id;
                txbEmpleadosNombre.Text = emp.Nombre;
                txbEmpleadosDireccion.Text = emp.Direccion;
                txbEmpleadosRfc.Text = emp.Rfc;
                txbEmpleadosTelefono.Text = emp.Telefono;
                txbEmpleadosCorreo.Text = emp.Correo;
                txbEmpleadosSueldo.Text = emp.Sueldo;
                txbEmpleadosArea.Text = emp.Area;

                accionn = accion.Editar;
                PonerBotonesEmpleadosEnEdicion(true);

            }

        }

        private void btnEmpleadosGuardar_Click(object sender, RoutedEventArgs e)
        {

            if (accionn == accion.Nuevo)
            {
                Empleado emp = new Empleado()
                {
                    // Identificador = txbEmpleadoId.Text,
                    Nombre = txbEmpleadosNombre.Text,
                    Direccion = txbEmpleadosDireccion.Text,
                    Rfc = txbEmpleadosRfc.Text,
                    Telefono = txbEmpleadosTelefono.Text,
                    Correo = txbEmpleadosCorreo.Text,
                    Sueldo = txbEmpleadosSueldo.Text,
                    Area = txbEmpleadosArea.Text

                };
                if (manejadorEmpleados.Agregar(emp))
                {
                    MessageBox.Show("Empleado agregado correctamente  ", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeEmpleados();
                    ActualizarTablaEmpleados();
                    PonerBotonesEmpleadosEnEdicion(false);
                }
                else
                {
                    MessageBox.Show("El empleado no se pudo agregar  ", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Empleado emp = dtgEmpleados.SelectedItem as Empleado;
                emp.Nombre = txbEmpleadosNombre.Text;
                emp.Direccion = txbEmpleadosDireccion.Text;
                emp.Rfc = txbEmpleadosRfc.Text;
                emp.Telefono = txbEmpleadosTelefono.Text;
                emp.Correo = txbEmpleadosCorreo.Text;
                emp.Sueldo = txbEmpleadosSueldo.Text;
                emp.Area = txbEmpleadosArea.Text;

                if (manejadorEmpleados.Modificar(emp))
                {
                    MessageBox.Show("Empleado modificado correctamente  ", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeEmpleados();
                    ActualizarTablaEmpleados();
                    PonerBotonesEmpleadosEnEdicion(false);
                }
                else
                {
                    MessageBox.Show("El empleado no se pudo actualizar  ", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }


        }

        private void btnEmpleadosCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeEmpleados();
            PonerBotonesEmpleadosEnEdicion(false);
        }

        private void btnEmpleadosEliminar_Click(object sender, RoutedEventArgs e)
        {
            Empleado emp = dtgEmpleados.SelectedItem as Empleado;
            if (emp != null)
            {
                if (MessageBox.Show("Realmente deceas eliminar este empleado? ", "Inventarios", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorEmpleados.Eliminar(emp.Id))
                    {
                        MessageBox.Show("Empleado eliminado", "Inventario", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaEmpleados();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el empleado", "Inventario", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }


        private void btnProductosNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeProductos();
            PonerBotonesProductosEnEdicion(true);
            accionn = accion.Nuevo;
        }

        private void btnProductosEditar_Click(object sender, RoutedEventArgs e)
        {
            Producto emp = dtgProductos.SelectedItem as Producto;
            if (emp != null)
            {
                txbProductosId.Text = emp.Id;
                txbProductosNombre.Text = emp.Nombre;
                cmbProductosCategoria.Text = emp.Categoria;
                txbProductosDescripcion.Text = emp.Descripcion;
                txbProductosPrecioVenta.Text = emp.PrecioVenta;
                txbProductosPrecioCompra.Text = emp.PrecioVenta;
                txbProductosPresentacion.Text = emp.Presentacion;


                accionn = accion.Editar;
                PonerBotonesProductosEnEdicion(true);

            }
        }

        private void btnProductosGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (accionn == accion.Nuevo)
            {
                Producto emp = new Producto()
                {

                    Nombre = txbProductosNombre.Text,
                    Categoria = cmbProductosCategoria.Text,
                    Descripcion = txbProductosDescripcion.Text,
                    PrecioVenta = txbProductosPrecioVenta.Text,
                    PrecioCompra = txbProductosPrecioCompra.Text,
                    Presentacion = txbProductosPresentacion.Text


                };
                if (manejadorProductos.Agregar(emp))
                {
                    MessageBox.Show("Producto agregado correctamente  ", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeProductos();
                    ActualizarTablaProductos();
                    PonerBotonesProductosEnEdicion(false);
                }
                else
                {
                    MessageBox.Show("El producto no se pudo agregar  ", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Producto emp = dtgProductos.SelectedItem as Producto;
                emp.Nombre = txbProductosNombre.Text;
                emp.Categoria = cmbProductosCategoria.Text;
                emp.Descripcion = txbProductosDescripcion.Text;
                emp.PrecioVenta = txbProductosPrecioVenta.Text;
                emp.PrecioCompra = txbProductosPrecioCompra.Text;
                emp.Presentacion = txbProductosPresentacion.Text;


                if (manejadorProductos.Modificar(emp))
                {
                    MessageBox.Show("Productos modificado correctamente  ", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeProductos();
                    ActualizarTablaProductos();
                    PonerBotonesProductosEnEdicion(false);
                }
                else
                {
                    MessageBox.Show("El productos no se pudo actualizar  ", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void btnProductosCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeProductos();
            PonerBotonesProductosEnEdicion(false);
        }

        private void btnProductosEliminar_Click(object sender, RoutedEventArgs e)
        {
            Producto emp = dtgProductos.SelectedItem as Producto;
            if (emp != null)
            {
                if (MessageBox.Show("Realmente deceas eliminar este producto? ", "Inventarios", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorProductos.Eliminar(emp.Id))
                    {
                        MessageBox.Show("Producto eliminado", "Inventario", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaProductos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el producto", "Inventario", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

     
        private void btnClientesNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeClientes();
            PonerBotonesClienteEnEdicion(true);
            accionn = accion.Nuevo;
        }

        private void btnClientesEditar_Click(object sender, RoutedEventArgs e)
        {
            Cliente emp = dtgClientes.SelectedItem as Cliente;
            if (emp != null)
            {
                txbClientesId.Text = emp.Id;
                txbClientesNombre.Text = emp.Nombre;
                txbClientesDireccion.Text = emp.Direccion;
                txbClientesRfc.Text = emp.Rfc;
                txbClientesTelefono.Text = emp.Telefono;
                txbClientesCorreo.Text = emp.Correo;


                accionn = accion.Editar;
                PonerBotonesClienteEnEdicion(true);

            }
        }

        private void btnClientesGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (accionn == accion.Nuevo)
            {
                Cliente emp = new Cliente()
                {
                    // Identificador = txbEmpleadoId.Text,
                    Nombre = txbClientesNombre.Text,
                    Direccion = txbClientesDireccion.Text,
                    Rfc = txbClientesRfc.Text,
                    Telefono = txbClientesTelefono.Text,
                    Correo = txbClientesCorreo.Text,


                };
                if (manejadorClientes.Agregar(emp))
                {
                    MessageBox.Show("Cliente agregado correctamente  ", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeClientes();
                    ActualizarTablaClientes();
                    PonerBotonesClienteEnEdicion(false);
                }
                else
                {
                    MessageBox.Show("El cliente no se pudo agregar  ", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Cliente emp = dtgClientes.SelectedItem as Cliente;
                emp.Nombre = txbClientesNombre.Text;
                emp.Direccion = txbClientesDireccion.Text;
                emp.Rfc = txbClientesRfc.Text;
                emp.Telefono = txbClientesTelefono.Text;
                emp.Correo = txbClientesCorreo.Text;


                if (manejadorClientes.Modificar(emp))
                {
                    MessageBox.Show("Clientes modificado correctamente  ", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeClientes();
                    ActualizarTablaClientes();
                    PonerBotonesClienteEnEdicion(false);
                }
                else
                {
                    MessageBox.Show("El clientes no se pudo actualizar  ", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void btnClientesCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeClientes();
            PonerBotonesClienteEnEdicion(false);
        }

        private void btnClientesEliminar_Click(object sender, RoutedEventArgs e)
        {
            Cliente emp = dtgClientes.SelectedItem as Cliente;
            if (emp != null)
            {
                if (MessageBox.Show("Realmente deceas eliminar este cliente? ", "Inventarios", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorClientes.Eliminar(emp.Id))
                    {
                        MessageBox.Show("Cliente eliminado", "Inventario", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaClientes();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el cliente", "Inventario", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }


        private void btnCategoriaNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeCategoria();
            PonerBotonesCategoriaEnEdicion(true);
            accionn = accion.Nuevo;
        }

        private void btnCategoriaEditar_Click(object sender, RoutedEventArgs e)
        {
            Categoria emp = dtgCategoria.SelectedItem as Categoria;
            if (emp != null)
            {
                txbCategoriaId.Text = emp.Id;
                txbCategoriaCategoria.Text = emp.categoria;

                accionn = accion.Editar;
                PonerBotonesCategoriaEnEdicion(true);

            }
        }

        private void btnCategoriaGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (accionn == accion.Nuevo)
            {
                Categoria emp = new Categoria()
                {
                    // Identificador = txbEmpleadoId.Text,
                    categoria = txbCategoriaCategoria.Text,



                };
                if (manejadorCategoria.Agregar(emp))
                {
                    MessageBox.Show("Categoria agregada correctamente  ", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeCategoria();
                    ActualizarTablaCategoria();
                    PonerBotonesCategoriaEnEdicion(false);
                }
                else
                {
                    MessageBox.Show("La categoria no se pudo agregar  ", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Categoria emp = dtgCategoria.SelectedItem as Categoria;
                emp.categoria = txbCategoriaCategoria.Text;



                if (manejadorCategoria.Modificar(emp))
                {
                    MessageBox.Show("Categoria modificada correctamente  ", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeCategoria();
                    ActualizarTablaCategoria();
                    PonerBotonesCategoriaEnEdicion(false);
                }
                else
                {
                    MessageBox.Show("La Categoria no se pudo actualizar  ", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnCategoriaCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeCategoria();
            PonerBotonesCategoriaEnEdicion(false);
        }

        private void btnCategoriaEliminar_Click(object sender, RoutedEventArgs e)
        {
            Categoria emp = dtgCategoria.SelectedItem as Categoria;
            if (emp != null)
            {
                if (MessageBox.Show("Realmente deceas eliminar esta categoria? ", "Inventarios", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorCategoria.Eliminar(emp.Id))
                    {
                        MessageBox.Show("Categoria eliminada", "Inventario", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaCategoria();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la categoria", "Inventario", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }



        private void btnNuevaVenta_Click_1(object sender, RoutedEventArgs e)
        {
            PonerBotonesVentaEnEdicion(false);
            HabilitarcajasVenta(true);
            NuevaVenta2(false);
            CargarFormularioVenta();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbCantidad.Text))
            {
                MessageBox.Show("Falta la cantidad", "Ventas", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }



            if (dtgInventario.SelectedItem != null)
            {

                Producto a = dtgInventario.SelectedItem as Producto;
                venta b = new venta();
                b.NombreProducto = a.Nombre;
                b.Categoria = a.Categoria;
                b.Cantidad = int.Parse(txbCantidad.Text);
                b.PrecioVenta = float.Parse(a.PrecioVenta);
                b.Total = (b.Cantidad) * (b.PrecioVenta);
                venta.Add(b);
                AgregarTablaLista();
                txbCantidad.Clear();
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            venta emp = dtgListaProductos.SelectedItem as venta;
            if (emp != null)
            {

                txbCantidad.Text = emp.Cantidad.ToString();

                accionn = accion.Editar;
                PonerBotonesEmpleadosEnEdicion(true);
                n = false;
                venta.Remove(emp);
                // para lo de editar
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningua producto", "Producto", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Esta  seguro de cancelar toda la operación?\nSe descartara toda la venta", "Venta", MessageBoxButton.YesNo, MessageBoxImage.Question)) == MessageBoxResult.Yes)
            {
                venta = new List<venta>();
                dtgListaProductos.ItemsSource = null;
                //  PonerBotonesVentaEnEdicion(false);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dtgListaProductos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione la fila a eliminar.", "Venta", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("}esta seguro de eliminar este producto ", "Venta", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    venta p = dtgListaProductos.SelectedItem as venta;
                    venta.Remove(p);
                    CargarFormularioVenta();
                    MessageBox.Show("Producto eliminado Correctamente", "Venta", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void btnVenta_Click(object sender, RoutedEventArgs e)
        {
            if (venta.Count == 0)
            {
                MessageBox.Show("No cuenta con ningun producto en la lista para calcular", "Venta", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            float total = 0;
            double iva = 0.16;
            foreach (venta item in venta)
            {
                total += item.Total;
            }
           
            MessageBox.Show("AVISO DE LA VENTA \nTotal: $"+ total.ToString()+ "\nIva: $"+ (iva*total)+ "\nTotal a pagar: $"+(total+(total*iva)), "Venta", MessageBoxButton.OK, MessageBoxImage.Information);

            Vale reporte = new Vale (txbFolio.Text + ".poo");
            string dany = "";
            dany = string.Format("FARMACIA 'MI QUERIDO ENFERMITO'\n Fecha: {0} \n Folio de venta: {1} \n Cliente: {2} \n Empleado: {3} \n ", txbFecha.Text, txbFolio.Text, cmbCliente.Text, cmbEmpleado.Text);
            string ame = "";
            foreach (venta item in venta)
            {
                ame += string.Format("   --Producto: {0} \n Categoria: {1} \n Precio ${2} \n Cantidad: {3} \n Total a pagar ${4}  \n ", item.NombreProducto, item.Categoria, item.PrecioVenta, item.Cantidad, item.Total);
            }
            string informacion = string.Format("         Total: ${0} \n          Iva: ${1} \n          Total a pagar: ${2} \n", total.ToString(), (iva * total), (total + (total * iva)));
            reporte.Guardar(dany + ame + informacion);
            MessageBox.Show("Reporte Guardado : " + txbFolio.Text + ".poo", "Reporte", MessageBoxButton.OK, MessageBoxImage.Information);


         


            txbFolio.Clear();
            PonerBotonesVentaEnEdicion(true);
           
            NuevaVenta2(false);
            HabilitarcajasVenta(true);
            CargarFormularioVenta();
            
            txbCantidad.Clear();
            venta = new List<venta>();
          dtgListaProductos.ItemsSource = null;
        }

        private void GuardarLosDatosDeLaVenta() {
            if (n)
            {
                if (dtgInventario.SelectedItem != null)
                {

                    Producto a = dtgInventario.SelectedItem as Producto;
                    venta b = new venta();
                    b.NombreProducto = a.Nombre;
                    b.Categoria = a.Categoria;
                    b.Cantidad = int.Parse(txbCantidad.Text);
                    b.PrecioVenta = float.Parse(a.PrecioVenta);
                    b.Total = (b.Cantidad) * (b.PrecioVenta);
                    venta.Add(b);
                    AgregarTablaLista();
                    txbCantidad.Clear();
                }
                else
                {
                    MessageBox.Show("Seleccione datos de la tabla", "Ventas", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else {


                Producto a = dtgInventario.SelectedItem as Producto;
                venta b = new venta();
                venta c = new venta();
                b.NombreProducto = a.Nombre;
                b.Categoria = a.Categoria;
                b.Cantidad = int.Parse(txbCantidad.Text);
                b.PrecioVenta = float.Parse(a.PrecioVenta);
                b.Total = (b.Cantidad) * (b.PrecioVenta);
                //venta.Add(b);
                foreach (var item in venta)
                {
                    if (a.Nombre == item.NombreProducto)
                    {
                        b = item;
                    }
                }
                b.Cantidad = c.Cantidad;
                b.Categoria = c.Categoria;
                b.NombreProducto = c.NombreProducto;
                b.PrecioVenta = c.PrecioVenta;
                b.Total = b.Cantidad * b.PrecioVenta;

                AgregarTablaLista();
            }


        }

        private void AgregarTablaLista() {
            dtgListaProductos.ItemsSource = null;
            dtgListaProductos.ItemsSource = venta;
        }
    }
}
