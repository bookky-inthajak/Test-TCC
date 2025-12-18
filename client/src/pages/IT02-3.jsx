import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

export function WelcomePage() {
  const [username, setUsername] = useState("");
  const navigate = useNavigate();

  useEffect(() => {
    const token = localStorage.getItem("token");
    const Username = localStorage.getItem("username");

    if (!token) {
      navigate("/");
      return;
    }

    setUsername(Username);
  }, [navigate]);

  return (
    <div >
      <h2>Welcome User : {username}</h2>
    </div>
  );
}
