import React, { createContext, useState, useContext, useEffect } from "react";
import AsyncStorage from "@react-native-async-storage/async-storage";

// Az AuthContext létrehozása
const AuthContext = createContext();

// Az AuthProvider komponens
export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);
  const [token, setToken] = useState(null);
  const [role, setRole] = useState(null);

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
      }
    };

    loadStoredData();
  }, []);

  const login = async (userData, authToken, userRole) => {
    setUser(userData);
    setToken(authToken);
    setRole(userRole);

    // Adatok mentése az AsyncStorage-ba
    await AsyncStorage.setItem("user", JSON.stringify(userData));
    await AsyncStorage.setItem("token", authToken);
    await AsyncStorage.setItem("role", userRole);
  };

  const logout = async () => {
    setUser(null);
    setToken(null);
    setRole(null);

    // Adatok törlése az AsyncStorage-ból
    await AsyncStorage.removeItem("user");
    await AsyncStorage.removeItem("token");
    await AsyncStorage.removeItem("role");
  };

  return (
    <AuthContext.Provider value={{ user, token, role, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

// Custom hook az AuthContext használatához
export const useAuth = () => {
  return useContext(AuthContext);
};
