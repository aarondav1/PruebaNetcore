const productsSelect = document.getElementById("productsSelect");
const addButton = document.getElementById("addButton");
const itemsTable = document.getElementById("itemsTable");
const totalInput = document.getElementById("totalInput");
let items = [];

async function getProducts() {
  const response = await fetch("https://localhost:7245/api/Producto/ListarProductos");
  const products = await response.json();

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

addButton.addEventListener("click", () => {
  const productId = productsSelect.value;
  const product = products.find((p) => p.id === productId);
  addItem(product);
});

getProducts();
