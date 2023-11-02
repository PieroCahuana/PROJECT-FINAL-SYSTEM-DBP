/*Eliminar Cita - Secretaria*/
function abrirModalSC(idcita) {
    const modal = document.getElementById("miModalSC");
    modal.style.display = "block";
    modal.dataset.idcita = idcita;
}
function cerrarModalSC() {
    document.getElementById("miModalSC").style.display = "none";
}
function eliminarCitaSC() {
    const idcita = document.getElementById("miModalSC").dataset.idcita;
    cerrarModalSC();
    // Redireccionar a la vista de eliminación del paciente con el id correspondiente
    window.location.href = `/Proyecto/EliminarCitaS/${idcita}`;
}

/*Eliminar Cita - Paciente*/
function abrirModalPC(idcita) {
    const modal = document.getElementById("miModalPC");
    modal.style.display = "block";
    modal.dataset.idcita = idcita;
}
function cerrarModalPC() {
    document.getElementById("miModalPC").style.display = "none";
}
function eliminarCitaPC() {
    const idcita = document.getElementById("miModalPC").dataset.idcita;
    cerrarModalPC();
    // Redireccionar a la vista de eliminación del paciente con el id correspondiente
    window.location.href = `/Proyecto/EliminarCitaP/${idcita}`;
}

/*Eliminar Cita - Doctor*/
function abrirModalDC(idcita) {
    const modal = document.getElementById("miModalDC");
    modal.style.display = "block";
    modal.dataset.idcita = idcita;
}
function cerrarModalDC() {
    document.getElementById("miModalDC").style.display = "none";
}
function eliminarCitaDC() {
    const idcita = document.getElementById("miModalDC").dataset.idcita;
    cerrarModalDC();
    // Redireccionar a la vista de eliminación del paciente con el id correspondiente
    window.location.href = `/Proyecto/EliminarCitaD/${idcita}`;
}

/*Eliminar Paciente - Doctor*/
function abrirModalDP(idPaciente) {
    const modal = document.getElementById("miModalDP");
    modal.style.display = "block";
    modal.dataset.idPaciente = idPaciente;
}
function cerrarModalDP() {
    document.getElementById("miModalDP").style.display = "none";
}
function eliminarPacienteDP() {
    const idPaciente = document.getElementById("miModalDP").dataset.idPaciente;
    cerrarModalDP();
    // Redireccionar a la vista de eliminación del paciente con el id correspondiente
    window.location.href = `/Proyecto/EliminarpacienteD/${idPaciente}`;
}

/*Eliminar Paciente - Secretaria*/
function abrirModalSP(idPaciente) {
    const modal = document.getElementById("miModalSP");
    modal.style.display = "block";
    modal.dataset.idPaciente = idPaciente;
}
function cerrarModalSP() {
    document.getElementById("miModalSP").style.display = "none";
}
function eliminarPacienteSP() {
    const idPaciente = document.getElementById("miModalSP").dataset.idPaciente;
    cerrarModalSP();
    // Redireccionar a la vista de eliminación del paciente con el id correspondiente
    window.location.href = `/Proyecto/EliminarpacienteS/${idPaciente}`;
}

/*Eliminar Doctor - Secretaria*/
function abrirModalSD(idDoctor) {
    const modal = document.getElementById("miModalSD");
    modal.style.display = "block";
    modal.dataset.idDoctor = idDoctor;
}
function cerrarModalSD() {
    document.getElementById("miModalSD").style.display = "none";
}
function eliminarPacienteSD() {
    const idDoctor = document.getElementById("miModalSD").dataset.idDoctor;
    cerrarModalSD();
    // Redireccionar a la vista de eliminación del paciente con el id correspondiente
    window.location.href = `/Proyecto/EliminardoctorS/${idDoctor}`;
}

/*Eliminar Doctor - Admin*/
function abrirModalAD(idDoctor) {
    const modal = document.getElementById("miModalAD");
    modal.style.display = "block";
    modal.dataset.idDoctor = idDoctor;
}
function cerrarModalAD() {
    document.getElementById("miModalAD").style.display = "none";
}
function eliminarPacienteAD() {
    const idDoctor = document.getElementById("miModalAD").dataset.idDoctor;
    cerrarModalAD();
    // Redireccionar a la vista de eliminación del paciente con el id correspondiente
    window.location.href = `/Proyecto/EliminardoctorA/${idDoctor}`;
}

/*Eliminar Secretaria - Admin*/
function abrirModalAS(idSecretaria) {
    const modal = document.getElementById("miModalAS");
    modal.style.display = "block";
    modal.dataset.idSecretaria = idSecretaria;
}
function cerrarModalAS() {
    document.getElementById("miModalAS").style.display = "none";
}
function eliminarPacienteAS() {
    const idSecretaria = document.getElementById("miModalAS").dataset.idSecretaria;
    cerrarModalAS();
    // Redireccionar a la vista de eliminación del paciente con el id correspondiente
    window.location.href = `/Proyecto/Eliminarsecretaria/${idSecretaria}`;
}

/*Eliminar Paciente - Admin*/
function abrirModalAP(idPaciente) {
    const modal = document.getElementById("miModalAP");
    modal.style.display = "block";
    modal.dataset.idPaciente = idPaciente;
}
function cerrarModalAP() {
    document.getElementById("miModalAP").style.display = "none";
}
function eliminarPacienteAP() {
    const idPaciente = document.getElementById("miModalAP").dataset.idPaciente;
    cerrarModalAP();
    // Redireccionar a la vista de eliminación del paciente con el id correspondiente
    window.location.href = `/Proyecto/EliminarpacienteA/${idPaciente}`;
}

/*Grabar Paciente - Doctor*/
function abrirGrabarP() {
    const modal = document.getElementById("GrabarP");
    modal.style.display = "block";
}
function cerrarGrabarP() {
    document.getElementById("GrabarP").style.display = "none";
}

/*Grabar Paciente - Secretaria*/
function abrirGrabarSP() {
    const modal = document.getElementById("GrabarSP");
    modal.style.display = "block";
}
function cerrarGrabarSP() {
    document.getElementById("GrabarSP").style.display = "none";
}

/*Grabar Paciente - Administrador*/
function abrirGrabarAP() {
    const modal = document.getElementById("GrabarAP");
    modal.style.display = "block";
}
function cerrarGrabarAP() {
    document.getElementById("GrabarAP").style.display = "none";
}

/*Grabar Doctor - Secretaria*/
function abrirGrabarSD() {
    const modal = document.getElementById("GrabarSD");
    modal.style.display = "block";
}
function cerrarGrabarSD() {
    document.getElementById("GrabarSD").style.display = "none";
}

/*Grabar Doctor - Administrador*/
function abrirGrabarAD() {
    const modal = document.getElementById("GrabarAD");
    modal.style.display = "block";
}
function cerrarGrabarAD() {
    document.getElementById("GrabarAD").style.display = "none";
}

/*Grabar Secretaria - Administrador*/
function abrirGrabarAS() {
    const modal = document.getElementById("GrabarAS");
    modal.style.display = "block";
}
function cerrarGrabarAS() {
    document.getElementById("GrabarAS").style.display = "none";
}

/*Grabar Cita - Secretaria*/
function abrirGrabarSC() {
    const modal = document.getElementById("GrabarSC");
    modal.style.display = "block";
}
function cerrarGrabarSC() {
    document.getElementById("GrabarSC").style.display = "none";
}

/*Grabar especialidad - admin*/
function abrirGrabarAE() {
    const modal = document.getElementById("GrabarAE");
    modal.style.display = "block";
}
function cerrarGrabarAE() {
    document.getElementById("GrabarAE").style.display = "none";
}

/*Grabar especialidad - Secretaria*/
function abrirGrabarSE() {
    const modal = document.getElementById("GrabarSE");
    modal.style.display = "block";
}
function cerrarGrabarSE() {
    document.getElementById("GrabarSE").style.display = "none";
}

