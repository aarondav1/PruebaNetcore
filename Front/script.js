const productsSelect = document.getElementById("productsSelect");
const addButton = document.getElementById("addButton");
const itemsTable = document.getElementById("itemsTable");
const totalInput = document.getElementById("totalInput");
let items = [];
let products = [];

async function getProducts() {
  const response = await fetch("https://localhost:7245/api/Producto/ListarProductos");
  products = await response.json();
  products.forEach((product) => {
    const option = document.createElement("option");
    option.value = product.id;
    option.textContent = product.nombre;
    productsSelect.appendChild(option);
  });
}

function addItem(product) {
  const item = {
    product: product,
    quantity: 1,
  };
  const existingItem = items.find((i) => i.product.id === product.id);
  if (existingItem) {
    existingItem.quantity++;
  } else {
    items.push(item);
  }
  updateTable();
}

function removeItem(productId) {
  const itemIndex = items.findIndex((i) => i.product.id === productId);
  if (itemIndex > -1) {
    const item = items[itemIndex];
    item.quantity--;
    if (item.quantity === 0) {
      items.splice(itemIndex, 1);
    }
  }
  updateTable();
}

function updateTable() {
  itemsTable.innerHTML = `
    <thead>
      <tr>
        <th>Producto</th>
        <th>Precio Unitario</th>
        <th>Cantidad</th>
        <th>Subtotal</th>
        <th>Acciones</th>
      </tr>
    </thead>
    <tbody>
      ${items
        .map(
          (item) =>
            `<tr>
              <td>${item.product.nombre}</td>
              <td>${item.product.precio}</td>
              <td>${item.quantity}</td>
              <td>${item.product.precio * item.quantity}</td>
              <td>
                <button class="btn btn-danger btn-sm" onClick="removeItem(${
                  item.product.id
                })">
                  Eliminar
                </button>
              </td>
            </tr>`
        )
        .join("")}
    </tbody>
  `;

  totalInput.value = items.reduce(
    (total, item) => total + item.product.precio * item.quantity,
    0
  );
}


addButton.addEventListener("click", () => {
  console.log(products);

  const productId = productsSelect.value;
  const product = products.find((p) => p.id == productId);
  console.log(productId);

  if (product) {
    addItem(product);
  }
});


getProducts();
