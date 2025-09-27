async function cargarHabitaciones() {
  try {
    const res = await fetch("/api/habitaciones");
    if (!res.ok) throw new Error("Error al cargar habitaciones");

    const habitaciones = await res.json();
    const container = document.getElementById("cards-container");
    container.innerHTML = ""; // limpiar antes de insertar

    habitaciones.forEach(hab => {
      const card = document.createElement("div");
      card.className = "room-card-grid";

      card.innerHTML = `
        <img src="img/${hab.num}.jpg" alt="Habitación ${hab.tipo}">
        <div class="room-details-grid">
          <h3>${hab.tipo} #${hab.num}</h3>
          <p class="room-price">$${hab.precio} / noche</p>
          <p class="room-description-grid">
            ${hab.disponibilidad ? "Disponible" : "No disponible"}
          </p>
          <a href="#" class="btn-reservar-grid" ${hab.disponibilidad ? "" : "style='pointer-events:none;opacity:0.5;'"}>Reservar</a>
        </div>
      `;
      container.appendChild(card);
    });
  } catch (error) {
    console.error(error);
  }
}

// Ejecutar cuando cargue la página
window.onload = cargarHabitaciones;
