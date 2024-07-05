import React from "react";
import { AuthProvider } from "./Auth/AuthContext";
import Navigation from "./navigation";

export default function App() {
  return (
    <AuthProvider>
      <Navigation />
    </AuthProvider>
  );
}
