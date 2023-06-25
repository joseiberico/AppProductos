create database DBProductos

use DBProductos
drop table Productos
Create table Productos(
Id_Producto int primary key identity(1,1),
Nombre varchar(70) not null,
Descripcion VARCHAR(255),
Precio DECIMAL(10,2),
Categoria_id INT,
FOREIGN KEY (Categoria_id) REFERENCES Categoria(Id_categoria)
);

create table Usuario (
Id_Usuario int primary key identity(1,1),
Nombre varchar(70) not null,
Email VARCHAR(100) not null,
Contrasena VARCHAR(100) not null
)

Create table Cliente(
Id_Cliente int primary key identity(1,1),
Nombre varchar(70) not null,
Direccion VARCHAR(255) not null,
Telefono VARCHAR(20) not null
)

Create table Categoria(
Id_Categoria int primary key identity(1,1),
Nombre varchar(60) not null,
descripcion VARCHAR(255)
)


CREATE TABLE Venta (
Id_venta INT PRIMARY KEY,
Fecha_venta DATE,
Cliente_id INT,
Usuario_id INT,
FOREIGN KEY (Cliente_id) REFERENCES Cliente(Id_cliente),
FOREIGN KEY (Usuario_id) REFERENCES Usuario(Id_usuario)
);


Create table Detalle_Venta(
Id_detalle INT PRIMARY KEY identity(1,1),
Venta_id INT,
Producto_id INT,
Cantidad INT,
Precio_unitario DECIMAL(10,2),
FOREIGN KEY (Venta_id) REFERENCES Venta(Id_Venta),
FOREIGN KEY (Producto_id) REFERENCES Productos(Id_Producto)
)