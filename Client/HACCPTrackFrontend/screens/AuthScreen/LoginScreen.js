import { View, Text, TextInput, Button, StyleSheet } from "react-native";

import React, { useState } from "react";
import { useAuth } from "../../Auth/AuthContext";
import { useNavigation } from "@react-navigation/native";

export default function LoginScreen() {
  const { login } = useAuth();
  const navigation = useNavigation();

  const [email, setEmail] = useState({ value: "", error: "" });
  const [password, setPassword] = useState({ value: "", error: "" });
  const [loading, setLoading] = useState(false);

  const handleLogin = async () => {
    console.log("logging in...");
    setLoading(true);
    const response = await login(email.value, password.value);
    if (!response) {
      console.log("error when logging in");
      setLoading(false);
      return;
    }
    const { role } = response;
    if (role === "RestaurantAdmin") {
      navigation.navigate("RestaurantAdminHome");
    } else {
      navigation.navigate("Home");
    }
    setLoading(false);
  };
  return (
    <View style={styles.container}>
      <Text style={styles.title}>Login</Text>
      <TextInput
        style={styles.input}
        placeholder="Email"
        label="Email"
        returnKeyType="next"
        value={email.value}
        onChangeText={(text) => setEmail({ value: text, error: "" })}
        error={!!email.error}
        errorText={email.error}
        autoCapitalize="none"
        autoCompleteType="email"
        textContentType="emailAddress"
        keyboardType="email-address"
      />
      {email.error ? <Text style={styles.error}>{email.error}</Text> : null}
      <TextInput
        style={styles.input}
        placeholder="Password"
        returnKeyType="done"
        value={password.value}
        onChangeText={(text) => setPassword({ value: text, error: "" })}
        error={!!password.error}
        errorText={password.error}
        secureTextEntry
      />
      {password.error ? (
        <Text style={styles.error}>{password.error}</Text>
      ) : null}
      <View style={styles.buttonContainer}>
        <Button
          mode="contained"
          onPress={handleLogin}
          title={loading ? "Loading..." : "Login"}
          disabled={loading}
        ></Button>
        <Button
          style={styles.button}
          title="Go to Register"
          onPress={() => navigation.navigate("Register")}
        />
      </View>
    </View>
  );
}
const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
  },
  title: {
    fontSize: 24,
    marginBottom: 20,
  },
  input: {
    width: "80%",
    marginBottom: 10,
    padding: 10,
    borderWidth: 1,
    borderColor: "#ccc",
    borderRadius: 5,
  },
  buttonContainer: {
    width: "80%",
    marginBottom: 10,
    justifyContent: "space-between",
  },
  button: {
    flex: 1,
    backgroundColor: "red",
    paddingVertical: 10,
    paddingHorizontal: 20,
    borderRadius: 5,
    marginHorizontal: 5,
  },
  continue: {
    position: "absolute",
    bottom: 60,
  },
  error: {
    color: "red",
    marginBottom: 5,
  },
});
