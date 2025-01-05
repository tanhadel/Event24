document.addEventListener("DOMContentLoaded", function () {
    const hamburger = document.querySelector(".hamburger");
    const navbar = document.getElementById("navbar");

    if (!hamburger || !navbar) {
        console.error("Hamburger icon or navbar not found.");
        return;
    }

    hamburger.addEventListener("click", function () {
        navbar.classList.toggle("active");  // Lägg till/tar bort "active" från navbaren
        hamburger.classList.toggle("active");  // Lägg till/tar bort "active" från hamburgarikonen
    });
});
