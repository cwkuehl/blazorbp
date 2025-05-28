// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

/** Submit für ein bestimmtes Control.
 * @param ctrl Auslösendes Control.
 */
function submitc(ctrl) {
  // console.log('function submitc(ctrl)');
  if (ctrl == null) {
    alert('SubmitControl ohne Control.');
    return;
  }
  var ctrlid = ctrl.attr('name');
  var f = ctrl.closest('form');
  if (ctrlid == null || f == null || f.length <= 0) {
    alert('Nächstes Formular nicht gefunden.');
    return;
  }
  if (ctrlid != null) {
    var c = f.find('input[name="SubmitControl"]');
    if (c == null || c.length <= 0) {
      alert('SubmitControl fehlt in der Seite.');
      return;
    }
    var v = ctrlid.split('.');
    c.val(v[v.length - 1]); // 'Model.' oder 'ModalModel.' entfernen
  }
  // console.log('Vor f.submit();');
  window.onbeforeunload = null;
  f.submit();
  disableAllControls();
  // console.log('Vor window.onbeforeunload');
  // TODO 28.05.2025 Firefox Postback von Checkbox fragt nach Seite verlassen, bei Chrome bei allen Controls.
  // window.onbeforeunload = function() { return "Bitte zuerst abmelden, wenn Sie die Seite verlassen wollen."; }
}

function disableAllControls() {
  // Alle Formularelemente auf der Seite auswählen
  const controls = document.querySelectorAll('input, select, textarea, button, fieldset, optgroup');

  // Jedes Element durchgehen und das "disabled"-Attribut setzen
  controls.forEach(function(control) {
      control.disabled = true;
  });
}