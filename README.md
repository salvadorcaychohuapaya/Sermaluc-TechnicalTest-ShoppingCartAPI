# 🛒 Carrito de Compras API

API REST desarrollada en **.NET 8** como prueba técnica.

Permite gestionar un carrito de compras: agregar, actualizar, eliminar y listar productos, con validaciones según reglas del producto.

## 🚀 Requisitos

- .NET 8 SDK
- Visual Studio 2022 o VS Code

## ▶️ Ejecución

1. Clonar el repositorio
2. Restaurar dependencias

    dotnet restore

3. Ejecutar la API

    dotnet run --project Sermaluc.ShoppingCartAPI

4. Abrir Swagger en el navegador:

   https://localhost:5001/swagger

## 🔑 Endpoints principales

- **GET** `/api/cart` → Listar carrito
- **POST** `/api/cart/add` → Agregar producto
- **PATCH** `/api/cart/{itemId}/quantity?delta={n}` → Cambiar cantidad
- **DELETE** `/api/cart/{itemId}` → Eliminar producto

## 📌 Ejemplo de request

```json
{
  "productId": 3546345,
  "quantity": 1,
  "groups": [
    {
      "groupAttributeId": "241887",
      "attributes": [
        { "attributeId": 968636, "quantity": 1 }
      ]
    }
  ]
}
