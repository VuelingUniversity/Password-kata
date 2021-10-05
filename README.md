# PASSWORD-KATA
Basada en esta [kata de tddbuddy](http://tddbuddy.com/katas/Password.pdf)

Tienes que crear un WCf para almacenar y validar contraseñas.


Todas las contraseñas deben de estar *salted and hasted*[^bignote] (aunque puedes hacer algo mas simple, como pegar nombre y pass y darle la vuelta)
No necesitas iterar con un servidor de email (Si quieres puedes usar algo así) 

### Tiene que tener 2 funcionalidades 

* **AreValidUserCredentials** - ​método que toma un usuario y pass, el método llama a un servicio de encriptación de la pass ( salts & hashes) y este lo comprueba contra lo que hay guardado. Si machea devuelve true y si no ....

* **SendResetEmail** ​- método que toma un email. Si este está en la BBDD envía un email con un link de validación (inventarlo) . El link debe de incluir un token generado de manera aleatoria que expira en una hora

### Examples

> **AreValidUserCredentials(“userName”, “password”)** o si quieres **AreValidUserCredentials(request)** donde request tiene “userName”, “password” como requeridos.

> **SendResetEmail(“emailAddress”)**

### Requisitos
Haced una funcionalidad y luego los tests, antes de pasar a la siguiente funcionalidad, quiero ver MOQ, fluentassertions y hasta autofixture si es necesario, quiero ver más de un test.
O incluso si os sentís capaces escribid primero el test. 

### Hint

> ● Pasad un repositorio en memoria para el tema de comprobar si existe. En los tests usad una librería como MOQ

> ● Pasad un email mockeado para enviar el email. En los tests usad una librería como MOQ. Si te sientes valiente de implementarlo en la aplicación no, en los tests (mira [aquí](https://blog.elmah.io/how-to-send-emails-from-csharp-net-the-definitive-tutorial/))

Bonus
1) Modifica la lógica de SendResetEmail para que todas las llamadas que ocurran en una hora siempre incluyan el genere un nuevo token ( genere uno nuevo para el mismo email)
2) Passwords expiran en una hora y el usuario no puede usar ninguna de las últimas 5 
3) Implementa la encriptación. Mira [aquí](https://blog.elmah.io/how-to-send-emails-from-csharp-net-the-definitive-tutorial/).

[^bignote]: https://crackstation.net/hashing-security.htm