import React from "react";
import ReactDOM from "react-dom/client";
import Login from "../../Content.Client/Web/Login.tsx";
import "./style.css";

const root = ReactDOM.createRoot(document.getElementById("root")!);

root.render(<Login onSubmitName={(name: string) => console.log(name)} />);

