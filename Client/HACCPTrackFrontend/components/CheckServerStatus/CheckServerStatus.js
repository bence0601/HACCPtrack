import { useEffect, useState } from "react";
import { Text, View } from "react-native";
import { ActivityIndicator } from "react-native-paper";

export default function CheckServerStatus() {
  const [loading, setLoading] = useState(false);

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
