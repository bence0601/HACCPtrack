import { View, Text, TextInput, Button, StyleSheet } from "react-native";
import React from "react";

export default function RestaurantCreater({
  loading,
  handlePreviousStep,
  handleCreateRestaurant,
  restaurantName,
  setRestaurantName,
  address,
  setAddress,
}) {
  return (
    <>
      <Text style={styles.title}>Create Restaurant</Text>
      <TextInput
        style={styles.input}
        placeholder="Restaurant Name"
        value={restaurantName.value}
        onChangeText={(text) => setRestaurantName({ value: text, error: "" })}
        autoCapitalize="none"
      />
      {restaurantName.error ? (
        <Text style={styles.error}>{restaurantName.error}</Text>
      ) : null}

      <TextInput
        style={styles.input}
        placeholder="Address"
        value={address.value}
        onChangeText={(text) => setAddress({ value: text, error: "" })}
        autoCapitalize="none"
      />
      {address.error ? <Text style={styles.error}>{address.error}</Text> : null}

      <Button
        onPress={handleCreateRestaurant}
        mode="contained"
        disabled={loading}
      >
        {loading ? "Loading..." : "Create"}
      </Button>
      {handlePreviousStep && (
        <Button onPress={handlePreviousStep} mode="outlined" disabled={loading}>
          Back
        </Button>
      )}
    </>
  );
}
const styles = StyleSheet.create({
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
