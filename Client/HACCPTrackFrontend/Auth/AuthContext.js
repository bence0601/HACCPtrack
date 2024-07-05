import React, { createContext, useState, useContext, useEffect } from "react";
import AsyncStorage from "@react-native-async-storage/async-storage";
import API_BASE_URL from "../../config";

// Az AuthContext létrehozása
const AuthContext = createContext();

// Az AuthProvider komponens
export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);
  const [token, setToken] = useState(null);
  const [role, setRole] = useState(null);
  const [isSignedIn, setIsSignedIn] = useState(false);

  useEffect(() => {
    // Adatok betöltése az AsyncStorage-ból, amikor az alkalmazás elindul
    const loadStoredData = async () => {
      const storedUser = await AsyncStorage.getItem("user");
      const storedToken = await AsyncStorage.getItem("token");
      const storedRole = await AsyncStorage.getItem("role");

      if (storedUser && storedToken && storedRole) {
        setUser(JSON.parse(storedUser));
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
        body: JSON.stringify({ email, username, password, inviteCode }),
      });

      if (response.ok) {
        const data = await response.json();
        const { user, token, role } = data;

        // Mentés az állapotba és az AsyncStorage-ba
        setUser(user);
        setToken(token);
        setRole(role);
        setIsSignedIn(true);

        await AsyncStorage.setItem("user", JSON.stringify(user));
        await AsyncStorage.setItem("token", token);
        await AsyncStorage.setItem("role", role);

        return true;
      } else {
        console.error("Registration failed:", response.status);
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
        const { user, token, role } = data;

        // Mentés az állapotba és az AsyncStorage-ba
        setUser(user);
        setToken(token);
        setRole(role);
        setIsSignedIn(true);

        await AsyncStorage.setItem("user", JSON.stringify(user));
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
