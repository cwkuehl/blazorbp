export function onLoad() {
  // console.log('Loaded');
  // alert('onLoad');
}

var countdowntime = [];

function startCountdown() {
  window.onpagehide = function() {
    console.log('onpagehide clearInterval', countdowntime.toString());
    countdowntime.forEach(t => clearInterval(t));
    countdowntime = [];
  }
  const iv = Number(document.getElementById("countdowninterval").value);
  if (iv <= 0)
    return;
  let endTime = new Date();
  endTime.setSeconds(endTime.getSeconds() + iv);
  let timer = setInterval(function () {
    // Alle Timer außer dem letzten beenden.
    for (let i = 0; i < countdowntime.length - 1; i++) {
      clearInterval(countdowntime[i]);
    }
    // console.log('document.cookie: ' + document.cookie); // Die Expires-Eigenschaft aus dem Cookie lesen geht nicht.
    countdowntime = [countdowntime[countdowntime.length - 1]];
    let remainingSeconds = Math.floor((endTime - new Date()) / 1000);
    const cc = document.getElementById('countdown');
    if (cc)
      cc.textContent = '' + remainingSeconds + ' s';
    if (remainingSeconds <= 0) {
      window.onbeforeunload = null;
      // deprecated: window.onunload = function() { console.log('onunload xxx'); return null; }
      location.href = "/auth/logout";
      return false;
    }
  }, 990);
  countdowntime.push(timer);
}

export function onUpdate() {
  // console.log('Updated');
  // Unabsichtliches Schliessen der Seite verhindern.
  const angemeldet = $('#countdown').length > 0;
  if (angemeldet) {
    startCountdown();
    // TODO window.onbeforeunload = function() { return angemeldet ? "Bitte zuerst abmelden, wenn Sie die Seite verlassen wollen." : null; }
  }
  else
    window.onbeforeunload = null;
  $(document).ready(function() {
    // Suche nach dem Element mit dem Attribut 'autofocus' und setze den Fokus darauf.
    $('[autofocus]').first().focus();
    // Default Button hat die class btn-primary.
    // prevent submit on enter: https://chandradev819.in/2022/04/11/how-to-prevent-default-enter-key-behavior-on-entry-screen-in-blazor/
    document.body.addEventListener('keypress', e => {
      if (e.which == 13 && !e.target.matches('button[type=submit]')) {
        const form = e.composedPath().find(e => e.matches('form'))
        const submitButton = form && form.querySelector('button[type=submit]:not(.btn-primary):enabled'); // :enabled
        if (submitButton) {
          const preventSubmit = (e2) => {
            e2.preventDefault();
            return false;
          }
          // Browser emulates submit button click, when enter key is pressed, so we need to prevent that.
          form.addEventListener('click', preventSubmit, { once: true, capture: true });
          setTimeout(() => {
            form.removeEventListener('click', preventSubmit, { capture: true })
              // Default-Schaltfläche auslösen.
              const df = form && form.querySelector('button[type=submit].btn-primary');
            if (df) {
              $(df).trigger('click');
            }
          }, 0);
          // better clear the eventlistener despite once:true in case the keypress propagation has been stopped by some other eventhandler
        }
      }
    });
    // Modale Dialoge einblenden.
    const modals = $('.modal');
    if (modals.length)
    {
      // console.log('Modal einblenden');
      modals.on('shown.bs.modal', function() {
        $(this).find('.modal-dialog').draggable({
          handle: ".modal-header"
        });
        $(this).find('.modal-content').resizable({
          minHeight: 300,
          minWidth: 300
        });
      });
      // $('.modal').modal('show');
      modals.modal('hide');
      setTimeout(() => {
        modals.modal('show'); // Damit der modale Dialog nach einem OK wieder erscheint: hide und nach 0 ms show.
        $('[autofocus]').last().focus(); // Fokus auf das letzte Element (im modalen Dialog) setzen.
      }, 0);
    }
    // Drucken
    var anzahl = 0;
    $('#Drucken:not(.bound)').addClass('bound').click(function(e){
      e.preventDefault();
      console.log('Drucken');
      anzahl++;
      if (anzahl <= 1)
        window.print(); // Mehrfaches Erscheinen des Druck-Dialogs verhindern.
    });
    // Formularelemente vor dem Submit deaktivieren.
    const forms = document.querySelectorAll('form');
    forms.forEach(form => {
      form.addEventListener('submit', function(event) {
        setTimeout(function () { disableAllControls(); }, 1);
      });
    });
    // Screenshot erzeugen.
    // var node = document.getElementById('Seite');
    // if (node) {
    //   htmlToImage.toPng(node)
    //     .then(function (dataUrl) {
    //       var img = new Image();
    //       img.src = dataUrl;
    //       document.body.appendChild(img);
    //     })
    //     .catch(function (error) {
    //       console.error('oops, something went wrong!', error);
    //     });
    // }
    // alert('onUpdate');
  });
}

export function onDispose() {
  // console.log('Disposed');
  // alert('onDispose');
}
