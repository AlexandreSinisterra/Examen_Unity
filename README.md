# Examen_Unity

## Tutorial:

Para explicar el tutorial voy a ir separándolo en apartados en pequeños tramos.

### Setting

Al principio en edit -> proyect settings, tienes que activar en player la funcion del input y seleccionar "both" esto es para que en el futuro te funcione el movimiendo del player.

### objetos básicos

En el panel de la izquierda se crean los objetos básicos 3d:

- un plano(suelo)
- una esfera(jugador)
- y otro objeto que quieras(futuro pickup)

### configuracion de los objetos

ahora abajo del todo en assets se pueden crear materiales, ahí puede elegirse un color o configurarlo como quieras para después otorgarlo a un objeto, es decir, si crear un material rosa y lo arrastras al player, la bola será rosa.

### tags

Tenemos que definir cada objeto importante:

- seleccionamos el tag de player a la bola
- creamos y otorgamos el tag de pickup al pickup

### movimiento player

Para este apartado realizaremos un script que nos permita mover al jugador.

Para ello tendremos que añadir anteriormente el componente de rigidbody al player, para que tenga colision.

- al principio definimos la velocidad base que queremos que tenga
- en el script realizaremos una funcion start() que recoja el rigidbody.
- despues crearemos una funcion FixedUpdate() donde crearemos un vector y añadiendo los "Input.getAxis", obtendremos la direccion que apretamos las flechas, luego simplemente usaremos "AddForce" multiplicando el vector por la velocidad y se lo añadiremos a la variable que almacenamos el "rigidbody"

ahora terminado arrastramos el script al player

### movimiento camara

Ahora hacemos el script para el movimiento de la cámara.

Para ello acomodamos la cámara manuealmente en función al jugador, ya que lo seguirá (como cuando hacemos un void object y metemos otro objeto dentro de este)

- en el start() calculamos la distancia entre el jugador y la cámara
- con un LateUpdate() actualizamos la nueva función de la cámara segun la posición actual del jugador. (funciona como que en el start creamos y almacenamos en una variable un vector ya que tiene modulo[distancia], sentido[a donde orienta, la flecha del vecto], y posición[donde se situa] pero esta ultima se editara con el LateUpdate para estar siempre en el mismo sitio en relacion con la bola, como si el player tuviera un palo selfie)

Por ultimo asignamos el script a la cámara y arrastramos el player para que sepa a quien sigue.

### pickups

Para que el jugador cuando los toque desaparezcan podemos seleccionar el apartado "is trigger" del pickup en el collider.

Por ultimo cree un script con la funcion Update, que basicamente ira rotando el objeto mediante un vector.

### Extra

Hay cosas extra que realice que puedes ver como lo de los enemigos, cree una variable de vida al jugador y los enemigos le hace daño, si lo matan la bola desaparece y pierdes. Si recoges todos los pickups ganas y puedes matar a los cubos

## Parte 2

Parte 2 del examen

### basicos

añadi lo basico que esta descrito del tutorial, como el movimiento de la bola.

### movimiento enemigo

Funciona parecido a la cámara explicada en el tutorial. 

- se tienen que añadir las variables de rango de activacion y velocidad del enemigo.
- ademas cree una variable que almacena si el jugador esta cerca o no.
- El codigo funciona comparando las distancias del enemigo y del jugador, si es mayor al rango, pone que esta lejos y no hace nada; pero si entra en el rango el enemigo va hacia el jugador, restando 2 puntos (la posicion del player y enemigo) y así creando un vector al que solo tenemos que añadir la velocidad del enemigo.
- Esta dentro de una funcion "Update" para que se vaya actualizando al posicion a cada rato.

### colision del enemigo

Este es muy sencillo, se utilizan las funciones "OnCollision" y dentro de ellas se comprueba el tag de lo que esta tocando para asegurar que sea el jugador. Hay 3 tipos de "OnCollision":

- OnCollisionEnter -> cuando justo lo toca
- OnCollisionStay -> si lo sigue tocando
- OnCollisionExit -> cuando justo lo deja de tocar
