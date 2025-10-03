# 30-Days-30-Games-Day-04-Cube-Jumper

This is the fourth game from my "30 Days 30 Games" challenge and my first project developed in a 3D environment. It's a minimalist, one-button endless runner.

## 🚀 About the Game
The player controls a cube that automatically moves forward along a path. The only action the player can take is to jump. The goal is to jump over an endless series of procedurally spawned obstacles and survive for as long as possible to achieve a high score.

## 💡 Technical Highlights
* **Engine:** Unity (3D)
* **3D Physics-Based Jump:** Player control is handled using `Rigidbody.AddForce` with `ForceMode.Impulse` to create a sharp, responsive jump. A boolean flag, `canJump`, is managed via `OnCollisionEnter` and `OnCollisionExit` to prevent mid-air jumping.
* **Coroutine-Based Spawning:** Obstacles are spawned at random intervals using a `while` loop inside a coroutine for efficient and flexible object generation.
* **Time-Based Scoring:** The score increases every second using `InvokeRepeating`, directly rewarding the player's survival time.
* **Efficient Object Destruction:** The `OnBecameInvisible` method is used on obstacle prefabs to automatically destroy them once they move off-screen, keeping the scene clean and performant.

## ▶️ Play the Game!
You can play the game in your browser on its itch.io page:
**https://shanmukha.itch.io/cube-jumper**
