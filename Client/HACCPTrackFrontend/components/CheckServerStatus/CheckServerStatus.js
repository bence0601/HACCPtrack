import { useEffect, useState } from "react";
import { Text, View } from "react-native";
import { ActivityIndicator } from "react-native-paper";
import API_BASE_URL from "../../config";

export default function CheckServerStatus() {
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const checkStatus = async () => {
      try {
        const response = await fetch(`${API_BASE_URL}/status`);
        if (response.ok) {
          const data = await response.json();
          if (data.status === "ok") {
            console.log("Server is now listening. (first fetch is working)");
            setLoading(false);
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
        <ActivityIndicator size="large" color="#5b5b5b" />
      ) : (
        <Text>Server is up and running</Text>
      )}
    </View>
  );
}
