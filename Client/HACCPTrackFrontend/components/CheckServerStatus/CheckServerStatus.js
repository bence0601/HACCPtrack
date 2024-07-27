import { useEffect, useState } from "react";
import { Text, View } from "react-native";
import { ActivityIndicator, Button } from "react-native-paper";
import API_BASE_URL from "../../config";
import { useNavigation } from "@react-navigation/native";

export default function CheckServerStatus() {
  const [loading, setLoading] = useState(true);
  const navigation = useNavigation();

  useEffect(() => {
    const checkStatus = async () => {
      try {
        const response = await fetch(`${API_BASE_URL}/status`);
        if (response.ok) {
          const data = await response.json();
          if (data.status === "ok") {
            console.log("Server is now listening. (first fetch is working)");
            setLoading(false);
          } else {
            console.error("Unexpected response data:", data);
          }
        } else {
          console.error("Server returned an error:", response.status);
        }
      } catch (error) {
        console.error("Error checking server status:", error);
      }
    };

    checkStatus();
  }, []);
  return (
    <View style={{ flex: 1, justifyContent: "center", alignItems: "center" }}>
      {loading ? (
        <>
          <Button title="Go to Register" />
          <ActivityIndicator size="large" color="#5b5b5b" />
        </>
      ) : (
        <>
          <Text onPress={() => navigation.navigate("Register")}>
            Go to Register
          </Text>
          <Text onPress={() => navigation.navigate("Login")}>Go to Login</Text>
        </>
      )}
    </View>
  );
}
