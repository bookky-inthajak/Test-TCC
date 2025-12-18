import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";

export default function LoginPage() {
  const [user, setUser] = useState("");
  const [password, setPassword] = useState("");
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [error, setError] = useState("");
  const navigate = useNavigate();

  const handleLogin = async (e) => {
    e.preventDefault();

     try {
      const response = await fetch("https://localhost:7181/api/login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          username: user,
          password: password,
        }),
      });

      if (!response.ok) {
        const message = await response.text();
        throw new Error(message);
      }

    const data = await response.json();


  localStorage.setItem("token", data.token);
  localStorage.setItem("username", data.user.username);
  localStorage.setItem("userId", data.user.id);

  navigate("/welcome");   
    } catch (err) {
      setError(err.message);
    }
  };

  return (
    <div>
      <form onSubmit={handleLogin} style={{ width: 300 }}>
        <div style={{ marginBottom: 10 }}>
          <label>User :</label>
          <input
            type="text"
            value={user}
            onChange={(e) => setUser(e.target.value)}
            style={{ width: "100%" }}
          />
        </div>

        <div style={{ marginBottom: 10 }}>
          <label>Password :</label>
          <input
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            style={{ width: "100%" }}
          />
        </div>

 
          <div style={{ color: "red", marginBottom: 10 }}>
            {error}
          </div>


        <button type="submit" style={{width:"100%"}}
        >
          Login
        </button>

        <div style={{ marginTop: 10, textAlign: "center" }}>
          <Link to="/register">Register</Link>
        </div>
      </form>
    </div>
  );
}
