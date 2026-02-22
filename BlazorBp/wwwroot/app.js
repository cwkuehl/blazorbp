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

/** Alle Controls deaktivieren.
 */
function disableAllControls() {
  // Alle Formularelemente auf der Seite auswählen
  const controls = document.querySelectorAll('input, select, textarea, button, fieldset, optgroup');

  // Jedes Element durchgehen und das "disabled"-Attribut setzen
  controls.forEach(function(control) {
      control.disabled = true;
  });
}

/** Ändert oder setzt den Bootstrap Dark Mode.
 * @param init Bootstrap Dark Mode aus localStorage initialisieren?
 * @returns Ist der Dark Mode aktiviert, wird true zurückgegeben, sonst false.
 */
function darklight(init) {
  // const root = document.documentElement;
  const root = document.getElementById("theme-root");
  var theme = localStorage.getItem('bstheme') || 'light';
  var dark = theme === 'dark';
  // var theme = root.getAttribute('data-bs-theme');
  if (init == null) {
    // Umschalten
    dark = !dark;
  }
  theme = dark ? 'dark' : 'light';
  root.setAttribute('data-bs-theme', theme);
  localStorage.setItem('bstheme', theme);
  // alert('Dark Mode ' + (dark ? 'aktiviert' : 'deaktiviert') + '.');
  return dark;
}

/** Ändert oder setzt den Bootstrap Dark Mode.
 * @param dataid Bootstrap Dark Mode aus localStorage initialisieren?
 * @returns nichts.
 */
function parseCanvasdata(dataid) {
  dataid = dataid || "canvasdata";
  const datactl = document.getElementById(dataid);
  if (datactl == null)
    return null;
  const raw = datactl.textContent;
  if (raw == null || raw.trim() === '')
    return null;
  // console.log('Canvas-Daten: ' + raw);
  const controls = JSON.parse(raw);
  if (controls == null)
    return null;
  for (const c of controls) {
    const canvas = document.getElementById(c.Canvasid);
    if (canvas == null)
      continue;
    const ctx = canvas.getContext("2d");
    if (ctx == null)
      continue;
    const commands = c.Commands;
    if (commands == null)
      continue;
    for (const command of commands) {
      switch (command.Cmd) {
        case "setFillStyle":
          ctx.fillStyle = command.Args.color;
          break;
        case "fillRect":
          ctx.fillRect(command.Args.x, command.Args.y, command.Args.w, command.Args.h);
          break;
        case "strokeRect":
          ctx.strokeRect(command.Args.x, command.Args.y, command.Args.w, command.Args.h);
          break;
        case "fillText":
          ctx.fillText(command.Args.text, command.Args.x, command.Args.y);
          break;
        case "setStrokeStyle":
          ctx.strokeStyle = command.Args.color;
          break;
        case "beginPath":
          ctx.beginPath();
          break;
        case "moveTo":
          ctx.moveTo(command.Args.x, command.Args.y);
          break;
        case "lineTo":
          ctx.lineTo(command.Args.x, command.Args.y);
          break;
        case "stroke":
          ctx.stroke();
          break;
        case "setFont":
          ctx.font = command.Args.font;
          break;
        case "rotate":
          ctx.rotate(command.Args.angle);
          break;
        case "arc":
          ctx.arc(command.Args.x, command.Args.y, command.Args.radius, command.Args.startangle, command.Args.endangle, command.Args.anticlockwise);
          break;
        default:
          console.warn("Unknown command:", command.Cmd);
      }
    }
  }
}