﻿using ApiProductos.Context;
using ApiProductos.Models;
using ApiProductos.Services.iServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ApiProductos.Services
{
    public class DetalleVentaServices : IRepository<Detalle_Venta>
    {
        private readonly DbSet<Detalle_Venta> _DbSet;
        private readonly ProductosDbContext _context;

        public DetalleVentaServices(ProductosDbContext context)
        {
            _context = context;
            _DbSet = context.Set<Detalle_Venta>();
        }

        public async Task<IEnumerable<Detalle_Venta>> GetAll()
        {
            return await _DbSet.ToListAsync();
        }

        public async Task<Detalle_Venta> GetById(int id)
        {
            return await _DbSet.FirstAsync(x => x.Id_detalle == id);
        }

        public async Task<Detalle_Venta> Create(Detalle_Venta entity)
        {
            Detalle_Venta detalleVenta = new Detalle_Venta()
            {
               
                Producto_id = entity.Producto_id,
                Cantidad = entity.Cantidad,
                Precio_unitario = entity.Precio_unitario
            };

            EntityEntry<Detalle_Venta> result = await _context.AddAsync(detalleVenta);
            await _context.SaveChangesAsync();
            return  result.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            Detalle_Venta entity = await GetById(id);
            if (entity == null)
            {
                return false;
            }

            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Detalle_Venta> Update(Detalle_Venta entity)
        {
            var detalleVenta = await GetById(entity.Id_detalle);

            if (detalleVenta == null)
            {
                return null;
            }
            detalleVenta.Venta_id = entity.Venta_id;
            detalleVenta.Producto_id = entity.Producto_id;
            detalleVenta.Cantidad = entity.Cantidad;
            detalleVenta.Precio_unitario = entity.Precio_unitario;


            await _context.SaveChangesAsync();
            return detalleVenta;
        }


    }
}
