import React, { useState } from "react";

interface LoginProps {
  onSubmitName: (name: string) => void;
}

const Login: React.FC<LoginProps> = ({ onSubmitName }) => {
  const [name, setName] = useState("");

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    onSubmitName(name);
  };

  return (
        <form className="login-form" onSubmit={handleSubmit}>
            <input className="login-input"
            type="text"
            value={name}
            onChange={(e) => setName(e.target.value)}
            />
            <button className="login-button" type="submit">Login</button>
        </form>
    );
};

export default Login;
