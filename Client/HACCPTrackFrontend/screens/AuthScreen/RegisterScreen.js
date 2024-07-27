import { View, Text, StyleSheet } from "react-native";
import React, { useState } from "react";
import { Button, TextInput } from "react-native-paper";
import { useAuth } from "../../Auth/AuthContext";

export default function RegisterScreen({ navigation }) {
  const [email, setEmail] = useState({ value: "", error: "" });
  const [username, setUsername] = useState({ value: "", error: "" });
  const [password, setPassword] = useState({ value: "", error: "" });
  const [inviteCode, setInviteCode] = useState("");
  const [loading, setLoading] = useState(false);
  const { register } = useAuth();

  const handleRegister = async () => {
    console.log("Registering...");
    setLoading(true);
    const response = await register(
      email.value,
      username.value,
      password.value,
      inviteCode
    );
    navigation.navigate("Login");
    if (!response) {
      console.log("err");
    }
  };

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Register</Text>
      <TextInput
        style={styles.input}
        placeholder="Email"
        value={email.value}
        onChangeText={(text) => setEmail({ value: text, error: "" })}
        keyboardType="email-address"
        autoCapitalize="none"
      />
      {email.error ? <Text style={styles.error}>{email.error}</Text> : null}

      <TextInput
        style={styles.input}
        placeholder="Username"
        value={username.value}
        onChangeText={(text) => setUsername({ value: text, error: "" })}
        autoCapitalize="none"
      />
      {username.error ? (
        <Text style={styles.error}>{username.error}</Text>
      ) : null}

      <TextInput
        style={styles.input}
        placeholder="Password"
        secureTextEntry
        value={password.value}
        onChangeText={(text) => setPassword({ value: text, error: "" })}
        autoCapitalize="none"
      />
      {password.error ? (
        <Text style={styles.error}>{password.error}</Text>
      ) : null}

      <TextInput
        style={styles.input}
        placeholder="Invite Code"
        value={inviteCode}
        onChangeText={(text) => setInviteCode(text)}
        autoCapitalize="none"
      />

      <Button onPress={handleRegister} mode="contained" disabled={loading}>
        {loading ? "Loading..." : "Register"}
      </Button>
      <Button
        title="Go to Login"
        onPress={() => navigation.navigate("Login")}
      />
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
    borderColor: "#ccc",
    borderWidth: 1,
    borderRadius: 5,
  },
  error: {
    color: "red",
    marginBottom: 10,
  },
  button: {
    flex: 1,
    backgroundColor: "red",
    paddingVertical: 10,
    paddingHorizontal: 20,
    borderRadius: 5,
    marginHorizontal: 5,
  },
});
