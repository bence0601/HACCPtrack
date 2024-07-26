import React, { createContext, useState, useContext, useEffect } from "react";
import AsyncStorage from "@react-native-async-storage/async-storage";
import API_BASE_URL from "../config";

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [email, setEmail] = useState(null);
  const [userName, setUserName] = useState(null);
  const [token, setToken] = useState(null);
  const [role, setRole] = useState(null);
  const [isSignedIn, setIsSignedIn] = useState(false);

  useEffect(() => {
    // Adatok betöltése az AsyncStorage-ból, amikor az alkalmazás elindul
    const loadStoredData = async () => {
      const storedEmail = await AsyncStorage.getItem("email");
      const storedUserName = await AsyncStorage.getItem("userName");
      const storedToken = await AsyncStorage.getItem("token");
      const storedRole = await AsyncStorage.getItem("role");

      if (storedUser && storedToken && storedRole) {
        setEmail(storedEmail);
        setUserName(storedUserName);
        setToken(storedToken);
        setRole(storedRole);
        setIsSignedIn(true);
      }
    };

    loadStoredData();
  }, []);

  const register = async (email, username, password, inviteCode) => {
    try {
      const response = await fetch(`${API_BASE_URL}/Auth/Register`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          email: email,
          username: username,
          password: password,
          inviteCode: inviteCode,
        }),
      });

      if (response.ok) {
        const data = await response.json();
        console.log("Registering success!");
        const { email, userName } = data;

        // Mentés az állapotba és az AsyncStorage-ba
        setEmail(email);
        setUserName(userName);

        await AsyncStorage.setItem("email", email);
        await AsyncStorage.setItem("userName", userName);

        return true;
      } else {
        console.error("Registration failed:", response.status, error.data);
        return false;
      }
    } catch (error) {
      console.error("Error during registration:", error);
      return false;
    }
  };

  const login = async (email, password) => {
    try {
      const response = await fetch(`${API_BASE_URL}/Auth/Login`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ email, password }),
      });

      if (response.ok) {
        const data = await response.json();
        const { email, userName, token, role } = data;

        // Mentés az állapotba és az AsyncStorage-ba
        setEmail(email);
        setUserName(userName);
        setToken(token);
        setRole(role);
        setIsSignedIn(true);

        await AsyncStorage.setItem("email", email);
        await AsyncStorage.setItem("userName", userName);
        await AsyncStorage.setItem("token", token);
        await AsyncStorage.setItem("role", role);

        return true;
      } else {
        console.error("Login failed:", response.status);
        return false;
      }
    } catch (error) {
      console.error("Error during login:", error);
      return false;
    }
  };

  const logout = async () => {
    setUser(null);
    setToken(null);
    setRole(null);
    setIsSignedIn(false);

    // Adatok törlése az AsyncStorage-ból
    await AsyncStorage.removeItem("user");
    await AsyncStorage.removeItem("token");
    await AsyncStorage.removeItem("role");
  };

  return (
    <AuthContext.Provider
      value={{ user, token, role, isSignedIn, register, login, logout }}
    >
      {children}
    </AuthContext.Provider>
  );
};

// Custom hook az AuthContext használatához
export const useAuth = () => {
  return useContext(AuthContext);
};
